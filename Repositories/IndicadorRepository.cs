using AE_RA7_RBM.Data;
using AE_RA7_RBM.Models;

namespace AE_RA7_RBM.Repositories
{
    public class IndicadorRepository : IIndicadorRepository
    {
        private readonly ApplicationDbContext _context;

        public IndicadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Indicador> GetAll()
        {
            return _context.Indicadores.ToList();
        }

        public Indicador? GetById(int id)
        {
            return _context.Indicadores.Find(id);
        }

        public IEnumerable<Indicador> GetByTipo(string tipo)
        {
            return _context.Indicadores
                           .Where(i => i.Tipo == tipo)
                           .ToList();
        }

        public IEnumerable<Indicador> GetByAmbito(string ambito)
        {
            return _context.Indicadores
                           .Where(i => i.Ambito == ambito)
                           .ToList();
        }

        public void Add(Indicador indicador)
        {
            _context.Indicadores.Add(indicador);
            _context.SaveChanges();
        }

        public void Update(Indicador indicador)
        {
            _context.Indicadores.Update(indicador);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var indicador = _context.Indicadores.Find(id);
            if (indicador != null)
            {
                _context.Indicadores.Remove(indicador);
                _context.SaveChanges();
            }
        }

        public Dictionary<string, int> GetTotalPorTipo()
        {
            return _context.Indicadores
                           .GroupBy(i => i.Tipo)
                           .ToDictionary(
                               g => g.Key,
                               g => g.Count()
                           );
        }
    }
}
