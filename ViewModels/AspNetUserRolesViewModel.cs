using Microsoft.AspNetCore.Mvc.Rendering;
using Capstone.Models;
using CapstoneProject.Models;

namespace CapstoneProject.ViewModels
{
	public class AspNetUserRolesViewModel
	{
		public UserRoleModel userRole { get; set; }
        public List<SelectListItem> Users { get; set; }
		public List<SelectListItem> Roles { get; set; }
	}
}
