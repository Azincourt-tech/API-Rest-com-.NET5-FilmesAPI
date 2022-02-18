using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int Id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = Id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new {Id = filme.Id}, filme);

        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
             Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                Ok(filme);  // 200            
            }
            return NotFound(); //404
        }

    }
}
