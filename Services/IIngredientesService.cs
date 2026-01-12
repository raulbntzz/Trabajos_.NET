using RecetasCocina_AE4.DTOs;

namespace RecetasCocina_AE4.Services
{
    public interface IIngredientesService
    {
        Task<IEnumerable<IngredienteDto>> ObtenerIngredientesUsuario(string usuarioId);
        Task<IngredienteDto?> ObtenerIngredientePorId(int id, string usuarioId);
        Task CrearIngrediente(IngredienteDto ingredienteDto, string usuarioId);
        Task ActualizarIngrediente(IngredienteDto ingredienteDto, string usuarioId);
        Task EliminarIngrediente(int id, string usuarioId);
    }
}
