using Microsoft.AspNetCore.Mvc;
using TorneoEsports.Data.Repositorios.Interfaces;

namespace TorneoEsports.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly IJugadorRepository _jugRepo;

        public JugadoresController(IJugadorRepository jugRepo)
        {
            _jugRepo = jugRepo;
        }

        public async Task<IActionResult> Index()
        {
            var jugadores = await _jugRepo.GetAllAsync();
            return View(jugadores);
        }

        public async Task<IActionResult> Details(int id)
        {
            var jugador = await _jugRepo.GetByIdAsync(id);
            if (jugador == null)
                return NotFound();

            return View(jugador);
        }
    }
}
