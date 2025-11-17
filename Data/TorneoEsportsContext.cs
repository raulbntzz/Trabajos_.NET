using Microsoft.EntityFrameworkCore;
using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Data
{
    public class TorneoEsportsContext : DbContext
    {
        public TorneoEsportsContext(DbContextOptions<TorneoEsportsContext> options)
            : base(options)
        {
        }

        public DbSet<Jugador> Jugadores { get; set; } = null!;
        public DbSet<Partida> Partidas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Partida>()
                .HasOne(p => p.Jugador)
                .WithMany(j => j.Partidas)
                .HasForeignKey(p => p.IdJugador)
                .HasConstraintName("FK_partida_jugador");
        }
    }
}
