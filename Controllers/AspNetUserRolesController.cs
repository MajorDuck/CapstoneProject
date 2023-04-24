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

namespace CapstoneProject.Controllers
{
    public class AspNetUserRoles : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AspNetUserRoles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
    }
}
