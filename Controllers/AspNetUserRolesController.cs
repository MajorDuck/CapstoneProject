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
            List<UserRoleModel> user_roles = new List<UserRoleModel>();
            foreach (var userRole in userRoles)
            {
                UserRoleModel user_role = new UserRoleModel();
                user_role.UserId = userRole.UserId;
                user_role.User = _context.Users.FirstOrDefault(u => u.Id == user_role.UserId);
                user_role.RoleId = userRole.RoleId;
                user_role.Role = _context.Roles.FirstOrDefault(r => r.Id == user_role.RoleId);
                user_roles.Add(user_role);
            }
            return View(user_roles);
        }
        public async Task<IActionResult> Details(string userId, string roleId)
        {
            var userRole = await _context.UserRoles.FindAsync(userId, roleId);
            UserRoleModel user_role = new UserRoleModel();
            user_role.UserId = userRole.UserId;
            user_role.User = _context.Users.FirstOrDefault(u => u.Id == user_role.UserId);
            user_role.RoleId = userRole.RoleId;
            user_role.Role = _context.Roles.FirstOrDefault(r => r.Id == user_role.RoleId);
            return View(user_role); 
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
        public async Task<IActionResult> Create(IdentityUserRole<string> userRole)
        {
            /*var userRoleConv = new IdentityUserRole<string>
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };
            var return_value = _context.UserRoles.Add(userRoleConv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
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

            var userRole = await _context.UserRoles.FindAsync(userId, roleId);

            if (userRole == null)
            {
                return NotFound();
            }

            UserRoleModel user_role = new UserRoleModel();
            user_role.UserId = userRole.UserId;
            user_role.User = _context.Users.FirstOrDefault(u => u.Id == user_role.UserId);
            user_role.RoleId = userRole.RoleId;
            user_role.Role = _context.Roles.FirstOrDefault(r => r.Id == user_role.RoleId);

            return View(user_role);
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
    }
}
