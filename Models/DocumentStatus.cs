using System.ComponentModel;

namespace Capstone.Models
{
	public class DocumentStatus
	{
		public int DocumentStatusID { get; set; }
        [DisplayName("Name")]
        public string DocumentStatusName { get; set; }
        [DisplayName("Color")]
        public string DocumentStatusColor { get; set; }
	}
}
