using Microsoft.AspNetCore.Mvc;
using TorneoEsports.Services.Interfaces;

namespace TorneoEsports.Controllers
{
    public class InformesController : Controller
    {
        private readonly IInformeService _service;

        public InformesController(IInformeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListadoJugadores()
        {
            var modelo = await _service.ListadoJugadoresAsync();
            return View(modelo);
        }

        public async Task<IActionResult> ListadoPartidas()
        {
            var modelo = await _service.ListadoPartidasAsync();
            return View(modelo);
        }

        public async Task<IActionResult> Promedios()
        {
            var modelo = await _service.ObtenerPromediosPorJugadorAsync();
            return View(modelo);
        }

        public async Task<IActionResult> ComparativaDano()
        {
            var modelo = await _service.ObtenerComparativaDanoAsync();
            return View(modelo);
        }

        public async Task<IActionResult> Top5()
        {
            var modelo = await _service.ObtenerTop5JugadoresAsync();
            return View(modelo);
        }
    }
}
