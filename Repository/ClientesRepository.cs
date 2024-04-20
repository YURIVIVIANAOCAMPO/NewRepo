using AlquilerVehiculos.Models;
using AlquilerVehiculos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AlquilerVehiculos.Repository
{
    public class ClientesRepository: IClientesRepository
    {
        public readonly AlquilerVehiculosContext _context;

        public ClientesRepository(AlquilerVehiculosContext context)
        {
            _context = context;
        }

        public bool Add(Cliente cliente)
        {
            _context.Clientes               
                .Add(cliente);
            return Save();
        }

        public bool Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return  _context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
