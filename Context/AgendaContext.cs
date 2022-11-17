using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AulaEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
namespace AulaEntityFramework.Context
{
    public class AgendaContext : DbContext
    {
        // construtor que define as config de conexão do DB (context)
        // a conexão é passada por parâmetro e em seguida é enviada para o base(DbContext)
        public AgendaContext (DbContextOptions<AgendaContext> options) : base (options)
        {
            // construtor é vazio pois só irá receber os parâmetros
        }

        // transformando a classe Contato em uma entidade (uma tabela no DB) chamada Contatos.
        public DbSet <Contato> Contatos { get; set; }
    }
}