using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace tsogosun.com.MSPatronDetails.Model.Dtos
{
    public class UnconfirmedGMSPatronDetailsInfoDto : PatronsDetailsInfoDto
    {		
		[NotMapped]
		public int? DocumentTypeId { get; set; }
		[NotMapped]
		public DateTime? DocumentExpireDate { get; set; }
		[NotMapped]
		public int? Pippep { get; set; }
	}
}
