using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using CapstoneProject.Data;

namespace CapstoneProject.Controllers
{
    public class LlcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LlcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Llcs
        public async Task<IActionResult> Index()
        {
              return _context.Llc != null ? 
                          View(await _context.Llc.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Llc'  is null.");
        }

        // GET: Llcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Llc == null)
            {
                return NotFound();
            }

            var llc = await _context.Llc
                .FirstOrDefaultAsync(m => m.LlcID == id);
            if (llc == null)
            {
                return NotFound();
            }

            return View(llc);
        }

        // GET: Llcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Llcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LlcID,LlcName")] Llc llc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(llc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(llc);
        }

        // GET: Llcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Llc == null)
            {
                return NotFound();
            }

            var llc = await _context.Llc.FindAsync(id);
            if (llc == null)
            {
                return NotFound();
            }
            return View(llc);
        }

        // POST: Llcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LlcID,LlcName")] Llc llc)
        {
            if (id != llc.LlcID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(llc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LlcExists(llc.LlcID))
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
            return View(llc);
        }

        // GET: Llcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Llc == null)
            {
                return NotFound();
            }

            var llc = await _context.Llc
                .FirstOrDefaultAsync(m => m.LlcID == id);
            if (llc == null)
            {
                return NotFound();
            }

            return View(llc);
        }

        // POST: Llcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Llc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Llc'  is null.");
            }
            var llc = await _context.Llc.FindAsync(id);
            if (llc != null)
            {
                _context.Llc.Remove(llc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LlcExists(int id)
        {
          return (_context.Llc?.Any(e => e.LlcID == id)).GetValueOrDefault();
        }
    }
}
