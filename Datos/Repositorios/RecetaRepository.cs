using Microsoft.EntityFrameworkCore;
using RecetasCocina_AE4.Models;

namespace RecetasCocina_AE4.Datos.Repositorios
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly ApplicationDbContext context;

        public RecetaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Receta>> GetAllByUserIdAsync(string usuarioId)
        {
            return await context.Recetas
                .Include(r => r.RecetaIngredientes)
                    .ThenInclude(ri => ri.Ingrediente)
                .Where(r => r.UsuarioId == usuarioId)
                .OrderByDescending(r => r.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Receta?> GetByIdAsync(int id, string usuarioId)
        {
            return await context.Recetas
                .Include(r => r.RecetaIngredientes)
                    .ThenInclude(ri => ri.Ingrediente)
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuarioId);
        }

        public async Task<Receta> CreateAsync(Receta receta)
        {
            context.Recetas.Add(receta);
            await context.SaveChangesAsync();
            return receta;
        }

        public async Task<Receta> UpdateAsync(Receta receta)
        {
            context.Entry(receta).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return receta;
        }

        public async Task<bool> DeleteAsync(int id, string usuarioId)
        {
            var receta = await context.Recetas
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuarioId);
            
            if (receta == null)
                return false;

            context.Recetas.Remove(receta);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id, string usuarioId)
        {
            return await context.Recetas
                .AnyAsync(r => r.Id == id && r.UsuarioId == usuarioId);
        }
    }
}
