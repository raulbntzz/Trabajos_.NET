using RecetasCocina_AE4.Models;

namespace RecetasCocina_AE4.Datos.Repositorios
{
    public interface IIngredienteRepository
    {
        Task<IEnumerable<Ingrediente>> GetAllByUserIdAsync(string usuarioId);
        Task<Ingrediente?> GetByIdAsync(int id, string usuarioId);
        Task<Ingrediente> CreateAsync(Ingrediente ingrediente);
        Task<Ingrediente> UpdateAsync(Ingrediente ingrediente);
        Task<bool> DeleteAsync(int id, string usuarioId);
        Task<bool> ExistsAsync(int id, string usuarioId);
    }
}
