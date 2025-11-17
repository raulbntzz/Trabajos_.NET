using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Data.Repositorios.Interfaces
{
    public interface IPartidaRepository
    {
        IQueryable<Partida> Query();
        Task<List<Partida>> GetAllAsync();
        Task<Partida?> GetByIdAsync(int id);
        Task AddAsync(Partida partida);
        Task UpdateAsync(Partida partida);
        Task DeleteAsync(int id);
    }
}
