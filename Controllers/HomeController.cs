using ContadorVisitasCookies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContadorVisitasCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // 1. Comprobar si existe la cookie "visitas"
            string? valorCookie = Request.Cookies["visitas"];
            int contador = 0;

            if (valorCookie != null)
            {
                // Convertir texto → número
                int.TryParse(valorCookie, out contador);
            }

            // 2. Incrementar contador
            contador++;

            // 3. Crear cookie usando el estilo del PDF (con CookieOptions)
            CookieOptions opciones = new CookieOptions();
            opciones.Expires = DateTime.Now.AddDays(7); // dura 7 días

            Response.Cookies.Append("visitas", contador.ToString(), opciones);

            // 4. Enviar el dato a la vista
            ViewBag.Visitas = contador;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
