using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KhumaloCraftWebApp.Data;
using KhumaloCraftWebApp.Models;

namespace KhumaloCraftWebApp.Controllers
{
    public class CraftworksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CraftworksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Craftworks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Craftworks.ToListAsync());
        }

        // GET: Craftworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var craftwork = await _context.Craftworks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (craftwork == null)
            {
                return NotFound();
            }

            return View(craftwork);
        }

        // GET: Craftworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Craftworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImagePath,Price")] Craftwork craftwork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(craftwork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(craftwork);
        }

        // GET: Craftworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var craftwork = await _context.Craftworks.FindAsync(id);
            if (craftwork == null)
            {
                return NotFound();
            }
            return View(craftwork);
        }

        // POST: Craftworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImagePath,Price")] Craftwork craftwork)
        {
            if (id != craftwork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(craftwork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CraftworkExists(craftwork.Id))
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
            return View(craftwork);
        }

        // GET: Craftworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var craftwork = await _context.Craftworks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (craftwork == null)
            {
                return NotFound();
            }

            return View(craftwork);
        }

        // POST: Craftworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var craftwork = await _context.Craftworks.FindAsync(id);
            if (craftwork != null)
            {
                _context.Craftworks.Remove(craftwork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CraftworkExists(int id)
        {
            return _context.Craftworks.Any(e => e.Id == id);
        }
    }
}
