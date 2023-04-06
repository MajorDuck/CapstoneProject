using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using CapstoneProject.Data;
using CapstoneProject.ViewModels;

namespace CapstoneProject.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
              return _context.Document != null ? 
                          View(await _context.Document.Include(d => d.DocumentType).Include(d => d.DocumentStatus)
                          .Include(d => d.Llc).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Document'  is null.");
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.Include(d => d.DocumentType).Include(d => d.DocumentStatus)
                .Include(d => d.Llc).FirstOrDefaultAsync(m => m.DocumentID == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            var document_statuses = _context.DocumentStatus.Select(a => new SelectListItem()
            {
                Value = a.DocumentStatusID.ToString(),
                Text = a.DocumentStatusName
            }).ToList();

            var document_types = _context.DocumentType.Select(a => new SelectListItem() { 
                Value = a.DocumentTypeID.ToString(),
                Text = a.DocumentTypeName
                }).ToList();

            var llcs = _context.Llc.Select(a => new SelectListItem()
            {
                Value = a.LlcID.ToString(),
                Text = a.LlcName
            }).ToList();

            var viewModel = new DocumentFormViewModel
            {
                DocumentStatuses = document_statuses,
                DocumentTypes = document_types,
                Llcs = llcs
            };
            return View(viewModel);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentID,DocumentTypeID,LlcID,CniPosRequestorUserID,CniContractNumber,ThirdParty,VersionNumber,DocumentStatusID,DraftedByUserID,DateLastUpdated,LinkToDocument")] Document document)
        {
            var errors = ModelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors) {
                Console.WriteLine($"\n\n\n{error.ErrorMessage}\n\n\n");
            }
            _context.Add(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            /*if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(new DocumentFormViewModel());*/
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document_statuses = _context.DocumentStatus.Select(a => new SelectListItem()
            {
                Value = a.DocumentStatusID.ToString(),
                Text = a.DocumentStatusName
            }).ToList();

            var document_types = _context.DocumentType.Select(a => new SelectListItem()
            {
                Value = a.DocumentTypeID.ToString(),
                Text = a.DocumentTypeName
            }).ToList();

            var llcs = _context.Llc.Select(a => new SelectListItem()
            {
                Value = a.LlcID.ToString(),
                Text = a.LlcName
            }).ToList();

            var document = await _context.Document.FindAsync(id);
            if (document == null) {
                return NotFound();
            }

            var viewModel = new DocumentFormViewModel
            {
                DocumentStatuses = document_statuses,
                DocumentTypes = document_types,
                Llcs = llcs,
                Document = document
            };

            return View(viewModel);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentID,DocumentTypeID,LlcID,CniPosRequestorUserID,CniContractNumber,ThirdParty,VersionNumber,DocumentStatusID,DraftedByUserID,DateLastUpdated,LinkToDocument")] Document document)
        {
            if (id != document.DocumentID)
            {
                return NotFound();
            }
            try
            {
                _context.Update(document);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(document.DocumentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            
            /*if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentID))
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
            return View(document);*/
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .FirstOrDefaultAsync(m => m.DocumentID == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Document == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Document'  is null.");
            }
            var document = await _context.Document.FindAsync(id);
            if (document != null)
            {
                _context.Document.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
          return (_context.Document?.Any(e => e.DocumentID == id)).GetValueOrDefault();
        }
    }
}
