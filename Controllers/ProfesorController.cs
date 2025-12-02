using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscuela.Controllers
{
    public class ProfesorController : Controller
    {
        [Authorize(Roles = "profesor,admin")]
        public IActionResult Calificar()
        {
            return View();
        }

        [Authorize(Roles = "profesor,admin")]
        public IActionResult PasarLista()
        {
            return View();
        }
    }
}
