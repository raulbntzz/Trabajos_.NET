using Microsoft.EntityFrameworkCore;
using TorneoEsports.Data.Repositorios.Interfaces;
using TorneoEsports.Models.DTOs;
using TorneoEsports.Models.Entidades;
using TorneoEsports.Services.Interfaces;

namespace TorneoEsports.Services
{
    public class InformeService : IInformeService
    {
        private readonly IJugadorRepository _jugRepo;
        private readonly IPartidaRepository _partRepo;

        public InformeService(IJugadorRepository jugRepo, IPartidaRepository partRepo)
        {
            _jugRepo = jugRepo;
            _partRepo = partRepo;
        }

        public async Task<List<Jugador>> ListadoJugadoresAsync() =>
            await _jugRepo.GetAllAsync();

        public async Task<List<PartidaDTO>> ListadoPartidasAsync()
        {
            return await _partRepo.Query()
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
                    DanoRecibido = p.DanoRecibido,
                    ObjetivosCapturados = p.ObjetivosCapturados,
                    Curaciones = p.Curaciones,
                    ExperienciaObtenida = p.ExperienciaObtenida
                }).ToListAsync();
        }

        public async Task<List<EstadisticasJugadorDTO>> ObtenerPromediosPorJugadorAsync()
        {
            return await _partRepo.Query()
                .GroupBy(p => new { p.IdJugador, p.Jugador.Nickname })
                .Select(g => new EstadisticasJugadorDTO
                {
                    IdJugador = g.Key.IdJugador,
                    Nickname = g.Key.Nickname,
                    PromedioAsesinatos = g.Average(x => x.Asesinatos),
                    PromedioMuertes = g.Average(x => x.Muertes),
                    PromedioAsistencias = g.Average(x => x.Asistencias),
                    PromedioDanoCausado = g.Average(x => x.DanoCausado),
                    PromedioPuntuacion = g.Average(x => x.Puntuacion)
                }).ToListAsync();
        }

        public async Task<List<ComparativaDanoDTO>> ObtenerComparativaDanoAsync()
        {
            return await _partRepo.Query()
                .GroupBy(p => p.Jugador.Nickname)
                .Select(g => new ComparativaDanoDTO
                {
                    Nickname = g.Key,
                    TotalDanoCausado = g.Sum(x => x.DanoCausado),
                    TotalDanoRecibido = g.Sum(x => x.DanoRecibido)
                }).ToListAsync();
        }

        public async Task<List<TopJugadorDTO>> ObtenerTop5JugadoresAsync()
        {
            return await _partRepo.Query()
                .GroupBy(p => p.Jugador.Nickname)
                .Select(g => new TopJugadorDTO
                {
                    Nickname = g.Key,
                    PuntuacionTotal = g.Sum(x => x.Puntuacion)
                })
                .OrderByDescending(x => x.PuntuacionTotal)
                .Take(5)
                .ToListAsync();
        }
    }
}
