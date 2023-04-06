using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;

namespace Capstone.Models
{
	public class Document
	{
		public int DocumentID { get; set; }
		public DocumentType DocumentType { get; set; }
		public int DocumentTypeID { get; set; }
		public Llc Llc { get; set; }
		public int LlcID { get; set; }

		public int CniPosRequestorUserID { get; set; }

		public string CniContractNumber { get; set; }
		public string? ThirdParty { get; set; }

		public int VersionNumber { get; set; }
		public DocumentStatus DocumentStatus { get; set; }
		public int DocumentStatusID { get; set; }

		public int DraftedByUserID { get; set; }

		public DateTime DateLastUpdated { get; set; }

		public string LinkToDocument { get; set; }

	}
}
