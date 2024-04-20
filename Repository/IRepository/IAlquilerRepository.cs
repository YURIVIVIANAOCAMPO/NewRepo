using AlquilerVehiculos.Models;

namespace AlquilerVehiculos.Repository.IRepository
{
    public interface IAlquilerRepository
    {
        ICollection<Alquiler> GetAll();
        ICollection<Alquiler> GetAllXDate(DateTime FechaInicio, DateTime FechaFin);
    }
}
