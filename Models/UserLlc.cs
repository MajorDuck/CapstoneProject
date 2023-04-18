using Capstone.Models;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.Models
{
	public class UserLlc
	{
        public int UserLlcId { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; } // Note: Aded after populating Controller and Views

        public int LlcId { get; set; }
        public Llc Llc { get; set; } // Note: Added after populating Controller and Views

    }
}
