using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Data.Repositorios.Interfaces
{
    public interface IJugadorRepository
    {
        IQueryable<Jugador> Query();
        Task<List<Jugador>> GetAllAsync();
        Task<Jugador?> GetByIdAsync(int id);
    }
}
