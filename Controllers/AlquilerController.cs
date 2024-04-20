using AlquilerVehiculos.Models;
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

        public JsonResult FilterAlquiler(DateTime FechaInicio,DateTime FechaFin)
        {
            List<Alquiler> odln = _AlquilerRepo.GetAllXDate(FechaInicio, FechaFin).ToList();
            return Json(new
            {
                isSuccess = true,
                html = Helper.RenderRazorViewToString(this, "_PartialIndex", odln),
                message = "Filtro Ejecutado"
            });

        }
    }
}
