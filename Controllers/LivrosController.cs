using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter_API.Models;
using Chapter_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter_API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_livroRepository.Listar());
        }
        // /api/livros/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Livro livro = _livroRepository.BuscarPorId(id);
            if (livro ==null)
            {
                return NotFound();
            }
            return Ok(livro);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            _livroRepository.Atualizar(id,livro);
            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            _livroRepository.Cadastrar(livro);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _livroRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
