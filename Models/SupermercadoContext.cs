using Microsoft.EntityFrameworkCore;

namespace EjercicioSupermercado.Models
{
    public class SupermercadoContext : DbContext
    {
        public SupermercadoContext(DbContextOptions<SupermercadoContext> options)
            : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalle>()
                .HasKey(d => new { d.IdPedido, d.IdProducto });

            // 🧩 Corrección clave: relación Producto–Categoria
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria)   // 👈 fuerza a usar idcategoria
                .HasConstraintName("FK_Producto_Categoria");
        }
    }
}
