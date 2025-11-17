using Microsoft.AspNetCore.Mvc;

namespace Juegos.Controllers
{
    public class PlataformasController : Controller
    {
        public IActionResult Consolas()
        {
            return View("Consolas");
        }
        public IActionResult Pc()
        {
            return View("Pc");
        }
        public IActionResult Cloud()
        {
            return View("Cloud");
        }


    }
}
