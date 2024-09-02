using Microsoft.EntityFrameworkCore;

namespace Varejo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto);

                entity.Property(e => e.NomeProduto)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Preco)
                      .HasColumnType("DECIMAL(10,2)")
                      .IsRequired();

                entity.Property(e => e.QuantidadeEstoque)
                      .IsRequired();

                entity.Property(e => e.NomeCategoria)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Fornecedor)
                      .HasMaxLength(100)
                      .IsRequired();
            });
        }
    }
}
