using TorneoEsports.Models.DTOs;
using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Services.Interfaces
{
    public interface IInformeService
    {
        Task<List<Jugador>> ListadoJugadoresAsync();
        Task<List<PartidaDTO>> ListadoPartidasAsync();
        Task<List<EstadisticasJugadorDTO>> ObtenerPromediosPorJugadorAsync();
        Task<List<ComparativaDanoDTO>> ObtenerComparativaDanoAsync();
        Task<List<TopJugadorDTO>> ObtenerTop5JugadoresAsync();
    }
}
