using Microsoft.EntityFrameworkCore;
using CadastroDeProduosAPI.Models.Produto;

namespace CadastroDeProduosAPI
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; } // O nome da DbSet geralmente é no plural para refletir a coleção de itens

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id); // Define explicitamente a chave primária

            base.OnModelCreating(modelBuilder);
        }
    }
}
