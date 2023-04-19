using System.ComponentModel;

namespace Capstone.Models
{
	public class DocumentType
	{
		public int DocumentTypeID { get; set; }
        [DisplayName("Name")]
        public string DocumentTypeName { get; set; }
	}
}
