using AlquilerVehiculos.Models;

namespace AlquilerVehiculos.Repository.IRepository
{
    public interface IClientesRepository
    {
        ICollection<Cliente> GetAll();
        Cliente GetById(int id);

        bool Add(Cliente cliente);
        bool Update(Cliente cliente);

        bool Delete(Cliente cliente);

        bool Save();
    }
}
