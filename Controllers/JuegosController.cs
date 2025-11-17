using Microsoft.AspNetCore.Mvc;

namespace Juegos.Controllers
{
    public class JuegosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Accion()
        {
            return View("Accion");
        }

        public IActionResult Aventura()
        {
            return View("Aventura");
        }

        public IActionResult Rol()
        {
            return View("Rol");
        }

        public IActionResult Estrategia()
        {
            return View("Estrategia");
        }
    }
}
