using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acxproject.Data;
using Acxproject.Models;

namespace Acxproject.Controllers
{
    public class CRMController : Controller
    {
        private readonly AppDbContext _context;

        public CRMController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CRM
        public async Task<IActionResult> Index()
        {
            return View(await _context.CRMUsers.ToListAsync());
        }

        // GET: CRM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRMUser = await _context.CRMUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cRMUser == null)
            {
                return NotFound();
            }

            return View(cRMUser);
        }

        // GET: CRM/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CRM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password")] CRMUser cRMUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRMUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cRMUser);
        }

         // GET: CRM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRMUser = await _context.CRMUsers.FindAsync(id);
            if (cRMUser == null)
            {
                return NotFound();
            }
            return View(cRMUser);
        }

        // POST: CRM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password")] CRMUser cRMUser)
        {
            if (id != cRMUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRMUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CRMUserExists(cRMUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cRMUser);
        }

        // GET: CRM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRMUser = await _context.CRMUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cRMUser == null)
            {
                return NotFound();
            }

            return View(cRMUser);
        }

        // POST: CRM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cRMUser = await _context.CRMUsers.FindAsync(id);
            if (cRMUser != null)
            {
                _context.CRMUsers.Remove(cRMUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CRMUserExists(int id)
        {
            return _context.CRMUsers.Any(e => e.Id == id);
        }
    }
}
