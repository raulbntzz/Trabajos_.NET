using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecetasCocina_AE4.DTOs;
using RecetasCocina_AE4.Models;
using RecetasCocina_AE4.Services;

namespace RecetasCocina_AE4.Controllers
{
    [Authorize]
    public class IngredientesController : Controller
    {
        private readonly IIngredientesService ingredientesService;
        private readonly UserManager<ApplicationUser> userManager;

        public IngredientesController(
            IIngredientesService ingredientesService,
            UserManager<ApplicationUser> userManager)
        {
            this.ingredientesService = ingredientesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);
            var ingredientes = await ingredientesService.ObtenerIngredientesUsuario(userId);
            return View(ingredientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IngredienteDto ingredienteDto)
        {
            if (!ModelState.IsValid)
                return View(ingredienteDto);

            var userId = userManager.GetUserId(User);
            await ingredientesService.CrearIngrediente(ingredienteDto, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = userManager.GetUserId(User);
            var ingrediente = await ingredientesService.ObtenerIngredientePorId(id, userId);

            if (ingrediente == null)
                return NotFound();

            return View(ingrediente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IngredienteDto ingredienteDto)
        {
            if (!ModelState.IsValid)
                return View(ingredienteDto);

            var userId = userManager.GetUserId(User);
            await ingredientesService.ActualizarIngrediente(ingredienteDto, userId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = userManager.GetUserId(User);
            var ingrediente = await ingredientesService.ObtenerIngredientePorId(id, userId);

            if (ingrediente == null)
                return NotFound();

            return View(ingrediente);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = userManager.GetUserId(User);
            await ingredientesService.EliminarIngrediente(id, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
