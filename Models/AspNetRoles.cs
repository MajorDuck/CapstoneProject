using System.ComponentModel;

namespace Capstone.Models
{
	public class AspNetRoles
    {
		public int LlcID { get; set; }
        [DisplayName("Name")]
        public string LlcName { get; set; }
	}
}
