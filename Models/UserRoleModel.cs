using System.ComponentModel;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.Models
{
	public class UserRoleModel
	{
        [DisplayName("User")]
        public string UserId { get; set; }
        [DisplayName("Role")]
        public string RoleId { get; set; }

    }
}
