using DenMed.Data;
using DenMed.Models;
using DenMed.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DenMed.Controllers
{
    public class SpecialistsController : Controller
    {
        private readonly ISpecialistRepo _repo;

        public SpecialistsController(ISpecialistRepo repo)
        {
            _repo = repo;
        }

        public ViewResult Index() => 
            View(_repo.Specialists);

        public ViewResult CreateSpecialist() =>
            View(new Specialist());

        [HttpPost]
        public IActionResult CreateSpecialist(Specialist specialist)
        {
            _repo.AddSpecialist(specialist);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteSpecialist(int specialistId)
        {
            
            _repo.DeleteSpecialist(specialistId);
            return RedirectToAction(nameof(Index));
        }
    }
}