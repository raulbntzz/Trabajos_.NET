using Microsoft.EntityFrameworkCore;
using TorneoEsports.Data.Repositorios.Interfaces;
using TorneoEsports.Models.Entidades;

namespace TorneoEsports.Data.Repositorios
{
    public class JugadorRepository : IJugadorRepository
    {
        private readonly TorneoEsportsContext _context;

        public JugadorRepository(TorneoEsportsContext context)
        {
            _context = context;
        }

        public IQueryable<Jugador> Query() => _context.Jugadores;

        public async Task<List<Jugador>> GetAllAsync() =>
            await _context.Jugadores.ToListAsync();

        public async Task<Jugador?> GetByIdAsync(int id) =>
            await _context.Jugadores
                .Include(j => j.Partidas)
                .FirstOrDefaultAsync(j => j.IdJugador == id);
    }
}
