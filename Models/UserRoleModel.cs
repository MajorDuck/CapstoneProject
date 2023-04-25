using System.ComponentModel;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.Models
{
	public class UserRoleModel
	{
        public IdentityUser User { get; set; }
        [DisplayName("User")]
        public string UserId { get; set; }
        public IdentityRole Role { get; set; }
        [DisplayName("Role")]
        public string RoleId { get; set; }

    }
}
