using Microsoft.EntityFrameworkCore;
using RecetasCocina_AE4.Models;

namespace RecetasCocina_AE4.Datos.Repositorios
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly ApplicationDbContext context;

        public IngredienteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Ingrediente>> GetAllByUserIdAsync(string usuarioId)
        {
            return await context.Ingredientes
                .Where(i => i.UsuarioId == usuarioId)
                .OrderBy(i => i.Nombre)
                .ToListAsync();
        }

        public async Task<Ingrediente?> GetByIdAsync(int id, string usuarioId)
        {
            return await context.Ingredientes
                .FirstOrDefaultAsync(i => i.Id == id && i.UsuarioId == usuarioId);
        }

        public async Task<Ingrediente> CreateAsync(Ingrediente ingrediente)
        {
            context.Ingredientes.Add(ingrediente);
            await context.SaveChangesAsync();
            return ingrediente;
        }

        public async Task<Ingrediente> UpdateAsync(Ingrediente ingrediente)
        {
            context.Entry(ingrediente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return ingrediente;
        }

        public async Task<bool> DeleteAsync(int id, string usuarioId)
        {
            var ingrediente = await context.Ingredientes
                .FirstOrDefaultAsync(i => i.Id == id && i.UsuarioId == usuarioId);
            
            if (ingrediente == null)
                return false;

            context.Ingredientes.Remove(ingrediente);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id, string usuarioId)
        {
            return await context.Ingredientes
                .AnyAsync(i => i.Id == id && i.UsuarioId == usuarioId);
        }
    }
}
