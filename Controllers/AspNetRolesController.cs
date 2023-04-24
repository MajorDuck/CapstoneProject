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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Drawing.Printing;
using System.Data;
using System.ComponentModel.DataAnnotations;



namespace CapstoneProject.Controllers
{
    public class AspNetRoles : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AspNetRoles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public async Task<IActionResult> Create(string roleName)
        {
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                if (await _roleManager.RoleExistsAsync(roleName))
                {
                    ModelState.AddModelError("", "Role already exists.");
                    return View();
                }

                var role = new IdentityRole(roleName);
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ModelState.AddModelError("", "Role not found.");
                return View();
            }

            return View(role);
        }
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ModelState.AddModelError("", "Role not found.");
                return View();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
        public async Task<IActionResult> Details(string id)
        {

            var role = await _roleManager.FindByIdAsync(id);

            return View(role);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        private async Task<bool> RoleExists(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return role != null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id, Name")] IdentityRole role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingRole = await _roleManager.FindByIdAsync(role.Id);
                    existingRole.Name = role.Name;

                    var result = await _roleManager.UpdateAsync(existingRole);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(role);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RoleExists(role.Id))
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
            return View(role);
        }
    }
}
