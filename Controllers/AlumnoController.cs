using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscuela.Controllers
{
    public class AlumnoController : Controller
    {
        [Authorize(Roles = "alumno,admin")]
        public IActionResult Expediente()
        {
            return View();
        }
    }
}
