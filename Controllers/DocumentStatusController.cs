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
    public class DocumentStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocumentStatus
        public async Task<IActionResult> Index()
        {
              return _context.DocumentStatus != null ? 
                          View(await _context.DocumentStatus.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DocumentStatus'  is null.");
        }

        // GET: DocumentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentStatus == null)
            {
                return NotFound();
            }

            var documentStatus = await _context.DocumentStatus
                .FirstOrDefaultAsync(m => m.DocumentStatusID == id);
            if (documentStatus == null)
            {
                return NotFound();
            }

            return View(documentStatus);
        }

        // GET: DocumentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentStatusID,DocumentStatusName,DocumentStatusColor")] DocumentStatus documentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentStatus);
        }

        // GET: DocumentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentStatus == null)
            {
                return NotFound();
            }

            var documentStatus = await _context.DocumentStatus.FindAsync(id);
            if (documentStatus == null)
            {
                return NotFound();
            }
            return View(documentStatus);
        }

        // POST: DocumentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentStatusID,DocumentStatusName,DocumentStatusColor")] DocumentStatus documentStatus)
        {
            if (id != documentStatus.DocumentStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentStatusExists(documentStatus.DocumentStatusID))
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
            return View(documentStatus);
        }

        // GET: DocumentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentStatus == null)
            {
                return NotFound();
            }

            var documentStatus = await _context.DocumentStatus
                .FirstOrDefaultAsync(m => m.DocumentStatusID == id);
            if (documentStatus == null)
            {
                return NotFound();
            }

            return View(documentStatus);
        }

        // POST: DocumentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentStatus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DocumentStatus'  is null.");
            }
            var documentStatus = await _context.DocumentStatus.FindAsync(id);
            if (documentStatus != null)
            {
                _context.DocumentStatus.Remove(documentStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentStatusExists(int id)
        {
          return (_context.DocumentStatus?.Any(e => e.DocumentStatusID == id)).GetValueOrDefault();
        }
    }
}
