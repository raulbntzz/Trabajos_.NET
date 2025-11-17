using Microsoft.EntityFrameworkCore;
using Taller_AE4.Models.Entity;


namespace Taller_AE4.Data
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {
        }


        public DbSet<Propietarios> Propietarios { get; set; }

        public DbSet<Marcas> Marcas { get; set; }

        public DbSet<Coches> Coches { get; set; }

        public DbSet<Mantenimientos> Mantenimientos { get; set; }

    }
}
