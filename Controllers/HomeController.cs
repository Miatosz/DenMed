using DenMed.Data;
using Microsoft.AspNetCore.Mvc;

namespace DenMed.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public ViewResult Index() =>
            View();
    }
}