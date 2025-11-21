using Microsoft.AspNetCore.Mvc;
using ProyectoRaulBenitezOscarSaez.Models;
using ProyectoRaulBenitezOscarSaez.Services;
using ProyectoRaulBenitezOscarSaez.Helpers;

namespace ProyectoRaulBenitezOscarSaez.Controllers
{
    public class TestController : Controller
    {
        private readonly TestGlobalService _global;

        public TestController(TestGlobalService global)
        {
            _global = global;
        }

        public IActionResult Index()
        {
            var testSesion = HttpContext.Session.GetObject<List<PreguntaSesion>>("test");

            if (testSesion == null)
            {
                testSesion = _global.Preguntas
                    .Select(p => new PreguntaSesion { Id = p.Id })
                    .ToList();

                HttpContext.Session.SetObject("test", testSesion);
            }

            ViewBag.TestSesion = testSesion;
            ViewBag.UltimaFecha = Request.Cookies["ultimaFecha"];

            return View(_global.Preguntas);
        }

        [HttpPost]
        public IActionResult Responder(int id, int respuesta)
        {
            var testSesion = HttpContext.Session.GetObject<List<PreguntaSesion>>("test");

            var preguntaGlobal = _global.Preguntas.First(p => p.Id == id);
            var preguntaSesion = testSesion.First(p => p.Id == id);

            // Verificar si es el PRIMER intento ANTES de incrementar
            bool esPrimerIntento = preguntaSesion.Intentos == 0;
            
            // Guardar el intento
            preguntaSesion.Intentos++;
            preguntaSesion.UltimaRespuesta = respuesta;

            // SUMAR AL GLOBAL solo si es primer intento Y es correcto
            if (esPrimerIntento && respuesta == preguntaGlobal.Correcta)
            {
                preguntaGlobal.AciertosGlobales++;
            }

            HttpContext.Session.SetObject("test", testSesion);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finalizar()
        {
            Response.Cookies.Append(
                "ultimaFecha",
                DateTime.Now.ToString("dd/MM/yyyy"),
                new CookieOptions { Expires = DateTime.Now.AddDays(30) }
            );

            // IMPORTANTE: Limpiar la sesión para permitir un nuevo test
            HttpContext.Session.Remove("test");

            return RedirectToAction("Index");
        }
    }
}
