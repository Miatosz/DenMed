using DenMed.Data;
using DenMed.Models;
using DenMed.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenMed.Controllers
{
    public class SurgeryController : Controller
    {
        private AppDbContext _context;
        private readonly ISurgeryRepo _repo;

        public SurgeryController(ISurgeryRepo repo, AppDbContext ctx)
        {
            _context = ctx;
            _repo = repo;
        }

        public ViewResult Index() =>
            View(_context.Surgeries);

        public ViewResult CreateSurgery() =>
            View(new Surgery());

        [HttpPost]
        public IActionResult CreateSurgery(Surgery surgery)
        {
            _repo.AddSurgery(surgery);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteSurgery(int surgeryId)
        {
            
            _repo.DeleteSurgery(surgeryId);
            return RedirectToAction(nameof(Index));
        }
        
    }
}