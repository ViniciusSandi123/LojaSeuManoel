using Loja.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) 
            : base(options) 
        { 
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Produtos)
                .WithOne(p => p.Pedido!)
                .HasForeignKey(p => p.PedidoId);
        }
    }
}
