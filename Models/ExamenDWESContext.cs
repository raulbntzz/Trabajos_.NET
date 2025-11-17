using Microsoft.EntityFrameworkCore;

namespace ExamenDWES.Models
{
    public class ExamenDWESContext : DbContext
    {
        public ExamenDWESContext(DbContextOptions<ExamenDWESContext> options)
            : base(options) { }

        public DbSet<Venta> Ventas { get; set; }
    }
}
