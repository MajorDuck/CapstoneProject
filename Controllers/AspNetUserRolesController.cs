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
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AspNetUserRoles : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public AspNetUserRoles(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Index()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return View(userRoles);
        }
        public async Task<IActionResult> Details(string userId, string roleId)
        {
            var user = await _context.UserRoles.FindAsync(userId, roleId);

            return View(user); 
        }

        public IActionResult Create()
        {

            var roles = _context.Roles.Select(a => new SelectListItem() // Get list of each LlcId and LlcName pair
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            var users = _context.Users.Select(a => new SelectListItem() // Get list of each user Id and Email pair
            {
                Value = a.Id.ToString(),
                Text = a.UserName
            }).ToList();

            var viewModel = new AspNetUserRolesViewModel // Combine lists to send
            {
                Users = users,
                Roles = roles
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRoleModel userRole)
        {
            if (ModelState.IsValid)
            {
                var userRoleConv = new IdentityUserRole<string>
                {
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId
                };
                _context.UserRoles.Add(userRoleConv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var roles = _context.Roles.Select(a => new SelectListItem() // Get list of each LlcId and LlcName pair
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            var users = _context.Users.Select(a => new SelectListItem() // Get list of each user Id and Email pair
            {
                Value = a.Id.ToString(),
                Text = a.UserName
            }).ToList();

            var viewModel = new AspNetUserRolesViewModel // Combine lists to send
            {
                Users = users,
                Roles = roles
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Delete(string userId, string roleId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var user = await _context.UserRoles.FindAsync(userId, roleId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string userId, string roleId)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserLlc'  is null.");
            }
            var userRole = await _context.UserRoles.FindAsync(userId, roleId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string userId, string roleId)
        {
            if (roleId == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles.FindAsync(userId, roleId);
            if (userRole == null)
            {
                return NotFound();
            }

            var newUserRole = new UserRoleModel
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };

            var roles = _context.Roles.Select(a => new SelectListItem() // Get list of each role
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            var users = _context.Users.Select(a => new SelectListItem() // Get list of each user
            {
                Value = a.Id.ToString(),
                Text = a.UserName
            }).ToList();

            var viewModel = new AspNetUserRolesViewModel // Combine lists to send
            {
                Users = users,
                Roles = roles,
                userRole = newUserRole
            };
            return View(viewModel);
        }
        private bool UserRoleExists(string userId, string roleId)
        {
            return _context.UserRoles.Any(e => e.UserId == userId && e.RoleId == roleId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("userId,roleId")] string userId, string roleId)
        {
            try
                {
                    // Check if the user role exists
                    var userRole = await _context.UserRoles.FindAsync(userId, roleId);
                    if (userRole == null)
                    {
                        return NotFound();
                    }

                    // Update the user role
                    userRole.UserId = userId;
                    userRole.RoleId = roleId;
                    _context.Update(userRole);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userId, roleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
        }

    }
}
