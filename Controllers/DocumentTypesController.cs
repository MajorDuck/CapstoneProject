using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using CapstoneProject.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CapstoneProject.Controllers
{
    public class DocumentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentTypesController(ApplicationDbContext context)
        {
			_context = context;
		}

		// GET: DocumentTypes
		[Authorize(Roles = "Administrators,ReadOnlyUsers")]
		public async Task<IActionResult> Index()
        {
              return _context.DocumentType != null ? 
                          View(await _context.DocumentType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DocumentType'  is null.");
        }

		// GET: DocumentTypes/Details/5
		[Authorize(Roles = "Administrators,ReadOnlyUsers")]
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentType == null)
            {
                return NotFound();
            }

            var documentType = await _context.DocumentType
                .FirstOrDefaultAsync(m => m.DocumentTypeID == id);
            if (documentType == null)
            {
                return NotFound();
            }

            return View(documentType);
        }

		// GET: DocumentTypes/Create
		[Authorize(Roles = "Administrators")]
		public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Create([Bind("DocumentTypeID,DocumentTypeName")] DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentType);
        }

		// GET: DocumentTypes/Edit/5
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentType == null)
            {
                return NotFound();
            }

            var documentType = await _context.DocumentType.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }
            return View(documentType);
        }

        // POST: DocumentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Edit(int id, [Bind("DocumentTypeID,DocumentTypeName")] DocumentType documentType)
        {
            if (id != documentType.DocumentTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentTypeExists(documentType.DocumentTypeID))
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
            return View(documentType);
        }

		// GET: DocumentTypes/Delete/5
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentType == null)
            {
                return NotFound();
            }

            var documentType = await _context.DocumentType
                .FirstOrDefaultAsync(m => m.DocumentTypeID == id);
            if (documentType == null)
            {
                return NotFound();
            }

            return View(documentType);
        }

        // POST: DocumentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrators")]
		public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DocumentType'  is null.");
            }
            var documentType = await _context.DocumentType.FindAsync(id);
            if (documentType != null)
            {
                _context.DocumentType.Remove(documentType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentTypeExists(int id)
        {
          return (_context.DocumentType?.Any(e => e.DocumentTypeID == id)).GetValueOrDefault();
        }
    }
}
