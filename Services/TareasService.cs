using IdentityDemo.Datos.Repositorios;
using IdentityDemo.DTOs;
using IdentityDemo.Models;
using System.Threading;


namespace IdentityDemo.Services
{
    public class TareasService : ITareasService
    {
        private readonly ITareaRepository tareaRepository;


        public TareasService(ITareaRepository tareaRepository)
        {
            this.tareaRepository = tareaRepository;
        }


        public IEnumerable<TareaDto> ObtenerTareasUsuario(string userId)
        {
            var tareas = tareaRepository.ObtenerPorUsuario(userId);


            return tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaCreacion = t.FechaCreacion,
                FechaCompletada = t.FechaCompletada
            });
        }

        public TareaDto? ObtenerTareaPorId(int id, string userId)
        {
            var tarea = tareaRepository.ObtenerPorId(id);
            
            if (tarea == null || tarea.UserId != userId)
                return null;
            
            return new TareaDto
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                Estado = tarea.Estado,
                FechaCreacion = tarea.FechaCreacion,
                FechaCompletada = tarea.FechaCompletada
            };
        }


        public void CrearTarea(TareaDto tareaDto, string userId)
        {
            var tarea = new Tarea
            {
                Titulo = tareaDto.Titulo,
                Descripcion = tareaDto.Descripcion,
                Estado = tareaDto.Estado,
                FechaCreacion = DateTime.Now,
                FechaCompletada = tareaDto.Estado == "Completada"
                    ? DateTime.Now
                    : null,
                UserId = userId
            };


            tareaRepository.Crear(tarea);
        }
        
        public void ActualizarTarea(TareaDto tareaDto, string userId)
        {
            var tareaExistente = tareaRepository.ObtenerPorId(tareaDto.Id);
            
            if (tareaExistente == null || tareaExistente.UserId != userId)
                return;
            
            tareaExistente.Titulo = tareaDto.Titulo;
            tareaExistente.Descripcion = tareaDto.Descripcion;
            tareaExistente.Estado = tareaDto.Estado;
            
            if (tareaDto.Estado == "Completada" && !tareaExistente.FechaCompletada.HasValue)
            {
                tareaExistente.FechaCompletada = DateTime.Now;
            }
            else if (tareaDto.Estado != "Completada")
            {
                tareaExistente.FechaCompletada = null;
            }
            
            tareaRepository.Actualizar(tareaExistente);
        }
        
        public void EliminarTarea(int id, string userId)
        {
            var tarea = tareaRepository.ObtenerPorId(id);
            
            if (tarea != null && tarea.UserId == userId)
            {
                tareaRepository.Eliminar(id);
            }
        }
    }
}
