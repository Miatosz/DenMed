using DenMed.Data;
using DenMed.Models;
using DenMed.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenMed.Controllers
{
    public class ReservationController : Controller
    {
        private AppDbContext _context;
        private readonly IReservationRepo _repo;

        public ReservationController(IReservationRepo repo, AppDbContext context)
        {
            _context = context;
            _repo = repo;
        }

        public ViewResult Index() => 
            View(_context.Reservations.Include(c => c.Customer).Include(c => c.Surgery));

        public ViewResult CreateReservation() =>
            View(new Reservation());

        [HttpPost]
        public IActionResult CreateReservation(Reservation reservation)
        {
            _repo.AddReservation(reservation);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteReservation(int reservationId)
        {
            
            _repo.DeleteReservation(reservationId);
            return RedirectToAction(nameof(Index));
        }
    }
}