using Microsoft.EntityFrameworkCore;
using TorneoEsports.Data.Repositorios.Interfaces;
using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Data.Repositorios
{
    public class PartidaRepository : IPartidaRepository
    {
        private readonly TorneoEsportsContext _context;

        public PartidaRepository(TorneoEsportsContext context)
        {
            _context = context;
        }

        public IQueryable<Partida> Query() =>
            _context.Partidas.Include(p => p.Jugador);

        public async Task<List<Partida>> GetAllAsync() =>
            await Query().ToListAsync();

        public async Task<Partida?> GetByIdAsync(int id) =>
            await Query().FirstOrDefaultAsync(p => p.IdPartida == id);

        public async Task AddAsync(Partida partida)
        {
            _context.Partidas.Add(partida);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Partida partida)
        {
            _context.Partidas.Update(partida);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);
            if (partida != null)
            {
                _context.Partidas.Remove(partida);
                await _context.SaveChangesAsync();
            }
        }
    }
}
