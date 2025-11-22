using Acxproject.Data;
using Acxproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acxproject.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var model = new CRMReport
            {
                TotalCustomers = _context.customers.Count(),
                TotalEmployees = _context.employees.Count(),
            };

            // If search empty → show last 5
            if (string.IsNullOrWhiteSpace(search))
            {
                model.RecentCustomers = _context.customers.Take(5).ToList();
                model.RecentEmployees = _context.employees.Take(5).ToList();
                return View(model);
            }

            string lower = search.ToLower();

            // Search results
            model.RecentCustomers = _context.customers
                .Where(c => c.Name.ToLower().Contains(lower) ||
                            c.Email.ToLower().Contains(lower))
                .ToList();

            model.RecentEmployees = _context.employees
                .Where(e => e.FirstName.ToLower().Contains(lower) ||
                            e.Email.ToLower().Contains(lower))
                .ToList();

            return View(model);
        }
    }
}
