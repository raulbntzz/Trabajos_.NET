using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TorneoEsports.Data.Repositorios.Interfaces;
using TorneoEsports.Models.DTOs;
using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Controllers
{
    public class PartidasController : Controller
    {
        private readonly IPartidaRepository _partRepo;
        private readonly IJugadorRepository _jugRepo;

        public PartidasController(IPartidaRepository partRepo, IJugadorRepository jugRepo)
        {
            _partRepo = partRepo;
            _jugRepo = jugRepo;
        }

        public async Task<IActionResult> Index()
        {
            var partidas = await _partRepo.Query()
                .Select(p => new PartidaDTO
                {
                    IdPartida = p.IdPartida,
                    IdJugador = p.IdJugador,
                    NicknameJugador = p.Jugador.Nickname,
                    FechaPartida = p.FechaPartida,
                    Mapa = p.Mapa,
                    DuracionMin = p.DuracionMin,
                    Puntuacion = p.Puntuacion,
                    Asesinatos = p.Asesinatos,
                    Muertes = p.Muertes,
                    Asistencias = p.Asistencias,
                    DanoCausado = p.DanoCausado,
                    DanoRecibido = p.DanoRecibido
                })
                .ToListAsync();

            return View(partidas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Jugadores = new SelectList(await _jugRepo.GetAllAsync(), "IdJugador", "Nickname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartidaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Jugadores = new SelectList(await _jugRepo.GetAllAsync(), "IdJugador", "Nickname");
                return View(dto);
            }

            var partida = new Partida
            {
                IdJugador = dto.IdJugador,
                FechaPartida = dto.FechaPartida,
                Mapa = dto.Mapa,
                DuracionMin = dto.DuracionMin,
                Puntuacion = dto.Puntuacion,
                Asesinatos = dto.Asesinatos,
                Muertes = dto.Muertes,
                Asistencias = dto.Asistencias,
                DanoCausado = dto.DanoCausado,
                DanoRecibido = dto.DanoRecibido,
                ObjetivosCapturados = dto.ObjetivosCapturados,
                Curaciones = dto.Curaciones,
                ExperienciaObtenida = dto.ExperienciaObtenida
            };

            await _partRepo.AddAsync(partida);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var partida = await _partRepo.GetByIdAsync(id);
            if (partida == null)
                return NotFound();

            var dto = new PartidaDTO
            {
                IdPartida = partida.IdPartida,
                IdJugador = partida.IdJugador,
                FechaPartida = partida.FechaPartida,
                Mapa = partida.Mapa,
                DuracionMin = partida.DuracionMin,
                Puntuacion = partida.Puntuacion,
                Asesinatos = partida.Asesinatos,
                Muertes = partida.Muertes,
                Asistencias = partida.Asistencias,
                DanoCausado = partida.DanoCausado,
                DanoRecibido = partida.DanoRecibido,
                ObjetivosCapturados = partida.ObjetivosCapturados,
                Curaciones = partida.Curaciones,
                ExperienciaObtenida = partida.ExperienciaObtenida
            };

            ViewBag.Jugadores = new SelectList(await _jugRepo.GetAllAsync(), "IdJugador", "Nickname", dto.IdJugador);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PartidaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Jugadores = new SelectList(await _jugRepo.GetAllAsync(), "IdJugador", "Nickname", dto.IdJugador);
                return View(dto);
            }

            var partida = new Partida
            {
                IdPartida = dto.IdPartida,
                IdJugador = dto.IdJugador,
                FechaPartida = dto.FechaPartida,
                Mapa = dto.Mapa,
                DuracionMin = dto.DuracionMin,
                Puntuacion = dto.Puntuacion,
                Asesinatos = dto.Asesinatos,
                Muertes = dto.Muertes,
                Asistencias = dto.Asistencias,
                DanoCausado = dto.DanoCausado,
                DanoRecibido = dto.DanoRecibido,
                ObjetivosCapturados = dto.ObjetivosCapturados,
                Curaciones = dto.Curaciones,
                ExperienciaObtenida = dto.ExperienciaObtenida
            };

            await _partRepo.UpdateAsync(partida);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var partida = await _partRepo.GetByIdAsync(id);
            if (partida == null)
                return NotFound();

            return View(partida);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _partRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var partida = await _partRepo.GetByIdAsync(id);
            if (partida == null)
                return NotFound();

            return View(partida);
        }
    }
}
