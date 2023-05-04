using Contato.Models;
using Microsoft.EntityFrameworkCore;

namespace Contato.Data
{
    public class AppDbContext : DbContext 
    {
        //construtor que modela como serão os atributos da classe 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSet -> é como se fosse minha tabala do banco
        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
