using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AulaEntityFramework.Entities;
using AulaEntityFramework.Context;

namespace AulaEntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        // recebe o banco de dados (o valor é passado no construtor)
        private readonly AgendaContext _context;

        // construtor que recebe o banco (context)
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        // as chaves especifica que vai receber um parâmetro.
        // o endpoint seria /Contato/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // o Contatos é o dbset (a tabela no BD)
            var contato = _context.Contatos.Find(id);
            // verificação do contato
            if (contato == null)
                return NotFound();

            return Ok(contato);
        }
    }
}