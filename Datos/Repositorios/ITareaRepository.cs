using IdentityDemo.Models;
using System.Threading;


namespace IdentityDemo.Datos.Repositorios
{
    public interface ITareaRepository
    {
        IEnumerable<Tarea> ObtenerPorUsuario(string userId);
        Tarea? ObtenerPorId(int id);
        void Crear(Tarea tarea);
        void Actualizar(Tarea tarea);
        void Eliminar(int id);
    }
}
