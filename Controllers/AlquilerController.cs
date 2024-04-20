using AlquilerVehiculos.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerVehiculos.Controllers
{
    public class AlquilerController : Controller
    {
        private readonly IAlquilerRepository _AlquilerRepo;
        public AlquilerController(IAlquilerRepository AlquilerRepo)
        {
            _AlquilerRepo = AlquilerRepo;
        }
        public IActionResult Index()
        {
            return View(_AlquilerRepo.GetAll());
        }
    }
}
