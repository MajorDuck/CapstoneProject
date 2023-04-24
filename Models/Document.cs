using Microsoft.AspNetCore.Identity;
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
        [DisplayName("Document Type")]
        public int DocumentTypeID { get; set; }
		public Llc Llc { get; set; }
        [DisplayName("LLC")]
        public int LlcID { get; set; }

		public IdentityUser? CniPosRequestorUser { get; set; }
        [DisplayName("CNI POS Requestor")]
        public string? CniPosRequestorUserID { get; set; }
        [DisplayName("CNI Contract Number")]
        public string? CniContractNumber { get; set; }
        [DisplayName("Third Party")]
        public string? ThirdParty { get; set; }
        [DisplayName("Version Number")]
        public int? VersionNumber { get; set; }
		public DocumentStatus DocumentStatus { get; set; }
        [DisplayName("Document Status")]
        public int DocumentStatusID { get; set; }
        public IdentityUser DraftedByUser { get; set; }
        [DisplayName("Drafted by User")]
        public string DraftedByUserID { get; set; }
        [DisplayName("Date Last Updated")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm tt}")]
		public DateTime DateLastUpdated { get; set; }
        [DisplayName("Link")]
        public string? LinkToDocument { get; set; }

        public Document()
        {
            DateLastUpdated = DateTime.Now;
        }

	}
}
