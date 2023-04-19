using System.ComponentModel;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.Models
{
	public class UserLlc
	{
        public int UserLlcId { get; set; }
        [DisplayName("Email")]
        public string UserEmail { get; set; }
        public IdentityUser User { get; set; } // Note: Aded after populating Controller and Views
        [DisplayName("LLC")]
        public int LlcId { get; set; }
        public Llc Llc { get; set; } // Note: Added after populating Controller and Views

    }
}
