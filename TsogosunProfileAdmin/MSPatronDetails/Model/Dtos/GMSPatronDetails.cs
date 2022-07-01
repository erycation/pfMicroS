using System;

namespace tsogosun.com.MSPatronDetails.Model.Dtos
{
    public class GMSPatronDetails
    {		
		public string IDPassportNumber { get; set; }
		public string CountryOfIssue { get; set; }
		public DateTime DocExpiryDate { get; set; } = DateTime.Now.AddYears(10);
		public string Nationality { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; } 
		public string Gender { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string PCID { get; set; }		
		public int ProvID { get; set; }
		public int CountryID { get; set; }
		public short PIPPEP { get; set; }
		public int DocumentType { get; set; }
		public bool AllowCommConsent { get; set; }
		public bool AllowCommSMS { get; set; }
		public bool AllowCommEmail { get; set; }
		public bool AllowCommPhone { get; set; }
		public bool AllowCommPost { get; set; }
		public string MobileNo { get; set; }
		public string LandLineNo { get; set; }
		public string Email { get; set; }
		public string Photo { get; set; }	

    }
}


	
	

