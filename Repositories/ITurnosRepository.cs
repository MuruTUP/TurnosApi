using PeluqueriaServiciosApi.Data.Models;

namespace PeluqueriaServiciosApi.Repositories
{
    public interface ITurnosRepository
    {
        bool Create(TTurno oTurno);
        List<TTurno> GetAll();
        TTurno GetById(int id);
        List<TTurno> GetByCliente(string cliente);

        bool Update(int id, TTurno oTurno);
        bool Delete(int id);
    }
}
