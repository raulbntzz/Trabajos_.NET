using RecetasCocina_AE4.Models;

namespace RecetasCocina_AE4.Datos.Repositorios
{
    public interface IRecetaRepository
    {
        Task<IEnumerable<Receta>> GetAllByUserIdAsync(string usuarioId);
        Task<Receta?> GetByIdAsync(int id, string usuarioId);
        Task<Receta> CreateAsync(Receta receta);
        Task<Receta> UpdateAsync(Receta receta);
        Task<bool> DeleteAsync(int id, string usuarioId);
        Task<bool> ExistsAsync(int id, string usuarioId);
    }
}
