using AE_RA7_RBM.Models;
using Microsoft.EntityFrameworkCore;

namespace AE_RA7_RBM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Indicador> Indicadores { get; set; }
    }
}

