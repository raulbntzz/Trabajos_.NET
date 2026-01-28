using AE_RA7_RBM.Models;

namespace AE_RA7_RBM.Repositories
{
    public interface IIndicadorRepository
    {
        IEnumerable<Indicador> GetAll();
        Indicador? GetById(int id);
        IEnumerable<Indicador> GetByTipo(string tipo);
        IEnumerable<Indicador> GetByAmbito(string ambito);

        void Add(Indicador indicador);

        void Update(Indicador indicador);

        void Delete(int id);

        Dictionary<string, int> GetTotalPorTipo();
    }
}
