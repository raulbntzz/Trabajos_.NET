using IdentityDemo.DTOs;
using IdentityDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IdentityDemo.Controllers
{
    [Authorize]
    public class TareasController : Controller
    {
        private readonly ITareasService tareasService;
        private readonly UserManager<IdentityUser> userManager;


        public TareasController(
            ITareasService tareasService,
            UserManager<IdentityUser> userManager)
        {
            this.tareasService = tareasService;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);


            var tareas = tareasService.ObtenerTareasUsuario(userId);


            return View(tareas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(TareaDto tareaDto)
        {
            if (!ModelState.IsValid)
                return View(tareaDto);


            var userId = userManager.GetUserId(User);


            tareasService.CrearTarea(tareaDto, userId);


            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = userManager.GetUserId(User);
            var tarea = tareasService.ObtenerTareaPorId(id, userId);
            
            if (tarea == null)
                return NotFound();
            
            return View(tarea);
        }
        
        [HttpPost]
        public IActionResult Edit(TareaDto tareaDto)
        {
            if (!ModelState.IsValid)
                return View(tareaDto);
            
            var userId = userManager.GetUserId(User);
            tareasService.ActualizarTarea(tareaDto, userId);
            
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = userManager.GetUserId(User);
            var tarea = tareasService.ObtenerTareaPorId(id, userId);
            
            if (tarea == null)
                return NotFound();
            
            return View(tarea);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = userManager.GetUserId(User);
            tareasService.EliminarTarea(id, userId);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
