using AlquilerVehiculos.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerVehiculos.Controllers
{
    public class ClienteController : Controller
    {
        private IClientesRepository _clientRepo;
        public ClienteController(IClientesRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }
        public IActionResult Index()
        {
            return View(_clientRepo.GetAll());
        }
    }
}
