using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSite.Data;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class TatliController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TatliController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: Tatli
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tatli.Include(t => t.DunyaMutfak).Include(t => t.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tatli/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatli = await _context.Tatli
                .Include(t => t.DunyaMutfak)
                .Include(t => t.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatli == null)
            {
                return NotFound();
            }

            return View(tatli);
        }

        // GET: Tatli/Create
        public IActionResult Create()
        {
            ViewData["DunyaMutfakId"] = new SelectList(_context.DunyaMutfak, "Id", "DunyaMutfakAd");
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "KategoriAd");
            return View();
        }

        // POST: Tatli/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Tarif,DunyaMutfakId,TatlıFoto,KategoriId,KisiSayisi")] Tatli tatli)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\tatli\");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                tatli.TatlıFoto = @"\images\tatli\" + fileName + extension;

                _context.Add(tatli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["DunyaMutfakId"] = new SelectList(_context.DunyaMutfak, "Id", "Id", tatli.DunyaMutfakId);
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", tatli.KategoriId);
            return View(tatli);
        }

        // GET: Tatli/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatli = await _context.Tatli.FindAsync(id);
            if (tatli == null)
            {
                return NotFound();
            }
            ViewData["DunyaMutfakId"] = new SelectList(_context.DunyaMutfak, "Id", "Id", tatli.DunyaMutfakId);
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", tatli.KategoriId);
            return View(tatli);
        }

        // POST: Tatli/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Tarif,DunyaMutfakId,TatlıFoto,KategoriId,KisiSayisi")] Tatli tatli)
        {
            if (id != tatli.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tatli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TatliExists(tatli.Id))
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
            ViewData["DunyaMutfakId"] = new SelectList(_context.DunyaMutfak, "Id", "Id", tatli.DunyaMutfakId);
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", tatli.KategoriId);
            return View(tatli);
        }

        // GET: Tatli/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tatli = await _context.Tatli
                .Include(t => t.DunyaMutfak)
                .Include(t => t.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatli == null)
            {
                return NotFound();
            }

            return View(tatli);
        }

        // POST: Tatli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tatli = await _context.Tatli.FindAsync(id);
            _context.Tatli.Remove(tatli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TatliExists(int id)
        {
            return _context.Tatli.Any(e => e.Id == id);
        }
    }
}
