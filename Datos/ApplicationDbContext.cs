using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecetasCocina_AE4.Models;

namespace RecetasCocina_AE4.Datos
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecetaIngrediente>()
                .HasKey(ri => new { ri.RecetaId, ri.IngredienteId });

            modelBuilder.Entity<RecetaIngrediente>()
                .HasOne(ri => ri.Receta)
                .WithMany(r => r.RecetaIngredientes)
                .HasForeignKey(ri => ri.RecetaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecetaIngrediente>()
                .HasOne(ri => ri.Ingrediente)
                .WithMany(i => i.RecetaIngredientes)
                .HasForeignKey(ri => ri.IngredienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Receta>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Recetas)
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ingrediente>()
                .HasOne(i => i.Usuario)
                .WithMany()
                .HasForeignKey(i => i.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
