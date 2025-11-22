using Acxproject.Data;
using Acxproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acxproject.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // -------- REGISTER --------
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CRMUser user)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.CRMUsers
                    .FirstOrDefaultAsync(x => x.Email == user.Email);

                if (exists != null)
                {
                    ViewBag.Msg = "Email already exists!";
                    return View();
                }

                _context.CRMUsers.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View(user);
        }

        // -------- LOGIN --------
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            var user = await _context.CRMUsers
                   .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        

            if (user == null)
            {
                ViewBag.Msg = "Invalid Email or Password";
                return View();
            }

            // NO SESSION
            // NO COOKIES
            // JUST REDIRECT

            return RedirectToAction("Dashboard", "main");
        }

        // -------- LOGOUT (Just Redirect) --------
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
