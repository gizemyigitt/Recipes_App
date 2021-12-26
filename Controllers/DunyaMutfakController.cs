using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSite.Data;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class DunyaMutfakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DunyaMutfakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DunyaMutfak
        public async Task<IActionResult> Index()
        {
            return View(await _context.DunyaMutfak.ToListAsync());
        }

        // GET: DunyaMutfak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dunyaMutfak = await _context.DunyaMutfak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dunyaMutfak == null)
            {
                return NotFound();
            }

            return View(dunyaMutfak);
        }

        // GET: DunyaMutfak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DunyaMutfak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DunyaMutfakAd")] DunyaMutfak dunyaMutfak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dunyaMutfak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dunyaMutfak);
        }

        // GET: DunyaMutfak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dunyaMutfak = await _context.DunyaMutfak.FindAsync(id);
            if (dunyaMutfak == null)
            {
                return NotFound();
            }
            return View(dunyaMutfak);
        }

        // POST: DunyaMutfak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DunyaMutfakAd")] DunyaMutfak dunyaMutfak)
        {
            if (id != dunyaMutfak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dunyaMutfak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DunyaMutfakExists(dunyaMutfak.Id))
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
            return View(dunyaMutfak);
        }

        // GET: DunyaMutfak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dunyaMutfak = await _context.DunyaMutfak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dunyaMutfak == null)
            {
                return NotFound();
            }

            return View(dunyaMutfak);
        }

        // POST: DunyaMutfak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dunyaMutfak = await _context.DunyaMutfak.FindAsync(id);
            _context.DunyaMutfak.Remove(dunyaMutfak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DunyaMutfakExists(int id)
        {
            return _context.DunyaMutfak.Any(e => e.Id == id);
        }
    }
}
