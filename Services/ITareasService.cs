using IdentityDemo.DTOs;


namespace IdentityDemo.Services
{
    public interface ITareasService
    {
        IEnumerable<TareaDto> ObtenerTareasUsuario(string userId);
        TareaDto? ObtenerTareaPorId(int id, string userId);
        void CrearTarea(TareaDto tareaDto, string userId);
        void ActualizarTarea(TareaDto tareaDto, string userId);
        void EliminarTarea(int id, string userId);
    }
}
