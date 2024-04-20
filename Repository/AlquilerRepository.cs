using AlquilerVehiculos.Models;
using AlquilerVehiculos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AlquilerVehiculos.Repository
{
    public class AlquilerRepository: IAlquilerRepository
    {
        public AlquilerVehiculosContext _context;
        public AlquilerRepository(AlquilerVehiculosContext context)
        {
            _context = context; 
        }

        public ICollection<Alquiler> GetAll()
        {
           return _context.Alquilers
                .Include(m=>m.IdClienteNavigation)
                .Include(m=>m.IdCarroNavigation)
                .ToList();
        }
    }
}
