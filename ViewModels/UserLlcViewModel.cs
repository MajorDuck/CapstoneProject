using Microsoft.AspNetCore.Mvc.Rendering;
using Capstone.Models;
using CapstoneProject.Models;

namespace CapstoneProject.ViewModels
{
	public class UserLlcViewModel
	{
		public UserLlc UserLlc { get; set; }
		public List<SelectListItem> Users { get; set; }
		public List<SelectListItem> Llcs { get; set; }
	}
}
