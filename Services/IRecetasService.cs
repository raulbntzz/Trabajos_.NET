using RecetasCocina_AE4.DTOs;

namespace RecetasCocina_AE4.Services
{
    public interface IRecetasService
    {
        Task<IEnumerable<RecetaDto>> ObtenerRecetasUsuario(string usuarioId);
        Task<RecetaDto?> ObtenerRecetaPorId(int id, string usuarioId);
        Task CrearReceta(RecetaDto recetaDto, string usuarioId);
        Task ActualizarReceta(RecetaDto recetaDto, string usuarioId);
        Task EliminarReceta(int id, string usuarioId);
        Task<bool> AgregarIngrediente(int recetaId, int ingredienteId, string cantidad, string usuarioId);
        Task<bool> EliminarIngrediente(int recetaId, int ingredienteId, string usuarioId);
    }
}
