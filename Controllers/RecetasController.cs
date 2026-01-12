using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecetasCocina_AE4.DTOs;
using RecetasCocina_AE4.Models;
using RecetasCocina_AE4.Services;

namespace RecetasCocina_AE4.Controllers
{
    [Authorize]
    public class RecetasController : Controller
    {
        private readonly IRecetasService recetasService;
        private readonly IIngredientesService ingredientesService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecetasController(
            IRecetasService recetasService,
            IIngredientesService ingredientesService,
            UserManager<ApplicationUser> userManager)
        {
            this.recetasService = recetasService;
            this.ingredientesService = ingredientesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);
            var recetas = await recetasService.ObtenerRecetasUsuario(userId);
            return View(recetas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecetaDto recetaDto)
        {
            if (!ModelState.IsValid)
                return View(recetaDto);

            var userId = userManager.GetUserId(User);
            await recetasService.CrearReceta(recetaDto, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = userManager.GetUserId(User);
            var receta = await recetasService.ObtenerRecetaPorId(id, userId);

            if (receta == null)
                return NotFound();

            return View(receta);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecetaDto recetaDto)
        {
            if (!ModelState.IsValid)
                return View(recetaDto);

            var userId = userManager.GetUserId(User);
            await recetasService.ActualizarReceta(recetaDto, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = userManager.GetUserId(User);
            var receta = await recetasService.ObtenerRecetaPorId(id, userId);

            if (receta == null)
                return NotFound();

            return View(receta);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = userManager.GetUserId(User);
            await recetasService.EliminarReceta(id, userId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManageIngredientes(int id)
        {
            var userId = userManager.GetUserId(User);
            var receta = await recetasService.ObtenerRecetaPorId(id, userId);

            if (receta == null)
                return NotFound();

            var todosIngredientes = await ingredientesService.ObtenerIngredientesUsuario(userId);

            ViewBag.RecetaId = id;
            ViewBag.RecetaNombre = receta.Nombre;
            ViewBag.TodosIngredientes = todosIngredientes;

            return View(receta);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngrediente(int recetaId, int ingredienteId, string cantidad)
        {
            var userId = userManager.GetUserId(User);
            await recetasService.AgregarIngrediente(recetaId, ingredienteId, cantidad, userId);

            return RedirectToAction(nameof(ManageIngredientes), new { id = recetaId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveIngrediente(int recetaId, int ingredienteId)
        {
            var userId = userManager.GetUserId(User);
            await recetasService.EliminarIngrediente(recetaId, ingredienteId, userId);

            return RedirectToAction(nameof(ManageIngredientes), new { id = recetaId });
        }
    }
}
