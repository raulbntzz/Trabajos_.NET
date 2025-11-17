using Microsoft.AspNetCore.Mvc;
namespace gatos.Controladores
{
    public class GatosController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }


        public IActionResult Persa()
        {
            return View("Persa");
        }


        public IActionResult Siames()
        {
            return View("Siames");
        }


        public IActionResult Bengali()
        {
            return View("Bengali");
        }
    }
}
