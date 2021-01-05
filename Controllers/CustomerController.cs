using DenMed.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DenMed.Data;
using Microsoft.EntityFrameworkCore;
using DenMed.Models;
using DenMed.Models.ViewModels;

namespace DenMed.Controllers
{
    public class CustomerController : Controller
    {
        private AppDbContext _context;
        private readonly ICustomerRepo _repo;

        public CustomerController(ICustomerRepo repo, AppDbContext ctx)
        {
            _context = ctx;
            _repo = repo;
        }

        public ViewResult Index() =>
            View(_context.Customers.Include(c => c.Adress));

        public ViewResult CreateCustomer() =>
            View(new Customer());

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _repo.SaveCustomer(customer);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCustomer(int customerId)
        {
            
            _repo.DeleteCustomer(customerId);
            return RedirectToAction(nameof(Index));
        }

        public ViewResult ViewCustomerReservations()
            => View(new LoginViewModel());

        [HttpPost]
        public IActionResult ViewCustomerReservations(LoginViewModel login)
        {
            var user = _repo.Customers.FirstOrDefault(c => c.Name == login.Name);
            if (user != null)
                return RedirectToAction("ListCustomerReservations", user);
            return RedirectToAction(nameof(ViewCustomerReservations));
        }

        public ViewResult ListCustomerReservations(Customer user)
        {
            var u = _context.Customers.Include(c => c.Reservations).ThenInclude(c => c.Surgery).FirstOrDefault(c => c.Id == user.Id);

            return View(u);
        }
        
    }
}