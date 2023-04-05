using Capstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapstoneProject.ViewModels
{
    public class DocumentFormViewModel
    {
        public Document Document { get; set; }
        public List<SelectListItem> DocumentTypes { get; set; }
        public List<SelectListItem> DocumentStatuses { get; set; }
        public List<SelectListItem> Llcs { get; set; }
    }
}
