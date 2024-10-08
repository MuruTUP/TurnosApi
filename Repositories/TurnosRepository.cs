using PeluqueriaServiciosApi.Data.Models;

namespace PeluqueriaServiciosApi.Repositories
{
    public class TurnosRepository : ITurnosRepository
    {
        private PeluqueriaDbContext _context;
        public TurnosRepository(PeluqueriaDbContext context)
        {
            _context = context;
        }


        public bool Create(TTurno oTurno)
        {
            if (Validar(oTurno))
            {
                oTurno.Id = 0;
                oTurno.Cancelado = false;
                _context.TTurnos.Add(oTurno);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        private bool Validar(TTurno oTurno)
        {
            return !string.IsNullOrEmpty(oTurno.Cliente) &&
                !string.IsNullOrEmpty(oTurno.Fecha) &&
                !string.IsNullOrEmpty(oTurno.Hora);
        }


        public bool Delete(int id)
        {
            var turnoBuscado = _context.TTurnos.Find(id);
            if (turnoBuscado != null && turnoBuscado.Cancelado == false)
            {
                turnoBuscado.Cancelado = true;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos.ToList();
        }

        public TTurno GetById(int id)
        {
            var cosoEncontrado = _context.TTurnos.Find(id);
            if (cosoEncontrado != null)
            {
                return cosoEncontrado;
            }
            return null;
        }


        public List<TTurno> GetByCliente(string cliente)
        {
            var turnosEncontrados = _context.TTurnos.Where(x => x.Cliente == cliente).ToList();
            if (turnosEncontrados != null)
            {
                return turnosEncontrados;
            }
            return null;
        }

        public bool Update(int id, TTurno oTurno)
        {
            var turnoEncontrado = GetById(id);
            if (turnoEncontrado != null && Validar(oTurno))
            {
                turnoEncontrado.Fecha = oTurno.Fecha;
                turnoEncontrado.Hora = oTurno.Hora;
                turnoEncontrado.Cliente = oTurno.Cliente;
                turnoEncontrado.Cancelado = oTurno.Cancelado;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
