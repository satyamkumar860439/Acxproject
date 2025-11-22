using Acxproject.Data;
using Acxproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Acxproject.Models.CRMReport;

namespace Acxproject.Controllers
{

    public class CRMReportController : Controller
    {
        private readonly AppDbContext _context;

        public CRMReportController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Report()
        {
            var viewModel = new CRMReport
            {
                TotalCustomers = await _context.customers.CountAsync(),
                TotalEmployees = await _context.employees.CountAsync(),
                RecentCustomers = await _context.customers
                    .OrderByDescending(x => x.Id)
                    .Take(5)
                    .ToListAsync(),
                RecentEmployees = await _context.employees
                    .OrderByDescending(x => x.Id)
                    .Take(5)
                    .ToListAsync()
            };

            return View(viewModel);
        }

    }

}
