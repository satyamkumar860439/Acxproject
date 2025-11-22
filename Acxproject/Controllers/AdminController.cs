using Acxproject.Data;
using Acxproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acxproject.Controllers
{
    public class AdminController:Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult  Customer()
        {
            var customers =  _context.customers.ToList();
            return View(customers);
        }
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer cus)
        {

            if (ModelState.IsValid)
            {
                _context.customers.Add(cus);
                _context.SaveChanges();
                return RedirectToAction("Customer");
            }
            return View(cus);
        }
        public  IActionResult Details(int id)
        {
            var customer =  _context.customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult Update(int id)
        {
            var customers = _context.customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.customers.Update(customer);
                _context.SaveChanges();
            }
            return View(customer);
        }
        public IActionResult deletepermission(int id)
        {
            var cus = _context.customers.Find(id);

            if (cus == null)
            {
                return RedirectToAction("customer");

            }            
            return View(cus);
        }

        [HttpPost, ActionName("DeletePermission")]
        public IActionResult Delete(int id)
        {
            var cus = _context.customers.Find(id);

            if (cus == null)
            {
                return NotFound();
            }

            _context.customers.Remove(cus);
            _context.SaveChanges();

            return RedirectToAction("Customer");
           
        }
       
    }
}
