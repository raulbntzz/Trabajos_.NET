using IdentityDemo.Models;
using System.Threading;


namespace IdentityDemo.Datos.Repositorios
{
    public class TareaRepository : ITareaRepository
    {
        private readonly ApplicationDbContext context;


        public TareaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<Tarea> ObtenerPorUsuario(string userId)
        {
            return context.Tareas
                          .Where(t => t.UserId == userId)
                          .OrderByDescending(t => t.FechaCreacion)
                          .ToList();
        }
        
        public Tarea? ObtenerPorId(int id)
        {
            return context.Tareas.Find(id);
        }
        
        public void Crear(Tarea tarea)
        {
            context.Tareas.Add(tarea);
            context.SaveChanges();
        }
        
        public void Actualizar(Tarea tarea)
        {
            context.Tareas.Update(tarea);
            context.SaveChanges();
        }
        
        public void Eliminar(int id)
        {
            var tarea = context.Tareas.Find(id);
            if (tarea != null)
            {
                context.Tareas.Remove(tarea);
                context.SaveChanges();
            }
        }
    }
}
