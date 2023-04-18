using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using CapstoneProject.ViewModels;

namespace CapstoneProject.Controllers
{
	[Authorize(Roles = "Administrators")]
	public class UserLlcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserLlcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserLlcs
        public async Task<IActionResult> Index()
        {
              return _context.UserLlc != null ? 
                          View(await _context.UserLlc
                            .Include(d => d.Llc)
                            .Include(d=> d.User)
                            .ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserLlc'  is null.");
		}

        // GET: UserLlcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserLlc == null)
            {
                return NotFound();
            }

            var userLlc = await _context.UserLlc
                .Include(d => d.Llc)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.UserLlcId == id);
            if (userLlc == null)
            {
                return NotFound();
            }

            return View(userLlc);
        }

        // GET: UserLlcs/Create
        public IActionResult Create()
        {

            var llcs = _context.Llc.Select(a => new SelectListItem()
            {
                Value = a.LlcID.ToString(),
                Text = a.LlcName
            }).ToList();

            var users = _context.Users.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Email
            }).ToList();

            var viewModel = new UserLlcViewModel
            {
                Users = users,
                Llcs = llcs
            };

            return View(viewModel);
        }

        // POST: UserLlcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserLlcId,UserId,LlcId")] UserLlc userLlc)
        {
            var errors = ModelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine($"\n\n\n{error.ErrorMessage}\n\n\n");
            }
            _context.Add(userLlc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            /*
            if (ModelState.IsValid)
            {
                _context.Add(userLlc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLlc);*/
        }

        // GET: UserLlcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserLlc == null)
            {
                return NotFound();
            }

            var userLlc = await _context.UserLlc.FindAsync(id);
            if (userLlc == null)
            {
                return NotFound();
            }

            var llcs = _context.Llc.Select(a => new SelectListItem()
            {
                Value = a.LlcID.ToString(),
                Text = a.LlcName
            }).ToList();

            var users = _context.Users.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Email
            }).ToList();

            var userllc = await _context.UserLlc.FindAsync(id);
            if (userllc == null)
            {
                return NotFound();
            }

            var viewModel = new UserLlcViewModel
            {
                UserLlc = userllc,
                Users = users,
                Llcs = llcs
            };

            return View(viewModel);
        }

        // POST: UserLlcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserLlcId,UserId,LlcId")] UserLlc userLlc)
        {
            if (id != userLlc.UserLlcId)
            {
                return NotFound();
            }
            try
            {
                _context.Update(userLlc);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLlcExists(userLlc.UserLlcId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            /*
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLlc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLlcExists(userLlc.UserLlcId))
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
            return View(userLlc);
            */
        }

        // GET: UserLlcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserLlc == null)
            {
                return NotFound();
            }

            var userLlc = await _context.UserLlc
                .Include(d => d.User)
                .Include(d => d.Llc)
                .FirstOrDefaultAsync(m => m.UserLlcId == id);
            if (userLlc == null)
            {
                return NotFound();
            }

            return View(userLlc);
        }

        // POST: UserLlcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserLlc == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserLlc'  is null.");
            }
            var userLlc = await _context.UserLlc.FindAsync(id);
            if (userLlc != null)
            {
                _context.UserLlc.Remove(userLlc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLlcExists(int id)
        {
          return (_context.UserLlc?.Any(e => e.UserLlcId == id)).GetValueOrDefault();
        }
    }
}
