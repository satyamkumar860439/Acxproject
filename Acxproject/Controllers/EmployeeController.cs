using Acxproject.Data;
using Acxproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Acxproject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext context;

        public EmployeeController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Employee()
        {
            var emp = context.employees.ToList();
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.employees.Add(emp);
                context.SaveChanges();

                return RedirectToAction("Employee");
            }

            return View(emp);
        }

        public IActionResult Details(int id)
        {

            var emp = context.employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        public IActionResult Update(int id)
        {
            var employee = context.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.employees.Update(employee);
                context.SaveChanges();
                return RedirectToAction("Employee");
            }
            return View(employee);
        }

        public IActionResult DeletePermission(int id)
        {
            var emp = context.employees.Find(id);

            if (emp == null)
            {
                return RedirectToAction("Employee");
            }

            return View(emp);
        }

        [HttpPost, ActionName("DeletePermission")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = context.employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            context.employees.Remove(emp);
            context.SaveChanges();

            return RedirectToAction("Employee");
        }


    }
}
