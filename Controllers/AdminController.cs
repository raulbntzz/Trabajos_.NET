using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityDemo.Services;
using IdentityDemo.Models;

namespace IdentityDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITareasService tareasService;

        public AdminController(UserManager<IdentityUser> userManager, ITareasService tareasService)
        {
            this.userManager = userManager;
            this.tareasService = tareasService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var usuarios = userManager.Users.ToList();
            var totalUsuarios = usuarios.Count;
            
            var estadisticas = new List<EstadisticaUsuario>();
            
            foreach (var usuario in usuarios)
            {
                var tareas = tareasService.ObtenerTareasUsuario(usuario.Id);
                var roles = await userManager.GetRolesAsync(usuario);
                
                estadisticas.Add(new EstadisticaUsuario
                {
                    Email = usuario.Email,
                    Roles = string.Join(", ", roles),
                    TotalTareas = tareas.Count(),
                    TareasPendientes = tareas.Count(t => t.Estado == "Pendiente"),
                    TareasEnProceso = tareas.Count(t => t.Estado == "EnProceso"),
                    TareasCompletadas = tareas.Count(t => t.Estado == "Completada")
                });
            }
            
            ViewBag.TotalUsuarios = totalUsuarios;
            return View(estadisticas);
        }
    }
}
