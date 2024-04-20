using AlquilerVehiculos.Models;

namespace AlquilerVehiculos.Repository.IRepository
{
    public interface IAlquilerRepository
    {
        ICollection<Alquiler> GetAll();
    }
}
