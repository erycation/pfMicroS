
using System;
using System.ComponentModel.DataAnnotations.Schema;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails
{
    public class PatronsDetailsInfoDto : PatronDetailsInfo
	{		
		public long? WebSiteID { get; set; }
		public Guid? MobileRegID { get; set; }
		public string EmailAddress { get; set; }
		public DateTime? BirthDate { get; set; }
		public bool? IsEmailVerified { get; set; }
		public string Nationality { get; set; }
		public string Title { get; set; }
		public string Gender { get; set; }
		public string IDPassImage { get; set; }
		public string IDPassCountry { get; set; }
		public string Occupation { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public bool? PreferredSms { get; set; }
		public bool? PreferredEmail { get; set; }
		public bool? PreferredPhoneCall { get; set; }
		public bool? PreferredPost { get; set; }
		public bool? ILikePromotions { get; set; }
		public bool? IsSigningUpForRewards { get; set; }
		public bool? IsNewSignUp { get; set; }
		public bool? IsProfileUpdate { get; set; }
		public DateTime InsertedDate { get; set; }
		public bool? IsSuburbCorrect { get; set; }
		public bool? IsCityCorrect { get; set; }
		public bool? IsProvinceCorrect { get; set; }
		public bool? IsCountryCorrect { get; set; }
		public bool? IsPostalCodeCorrect { get; set; }
		public bool? IsAddressCorrect { get; set; }
		public int? DocumentTypeId { get; set; }		
		public string Notes { get; set; }
		[NotMapped]
		public int? SiteID { get; set; }
		[NotMapped]
		public int? PcId { get; set; }
		[NotMapped]
		public string AdminUserName { get; set; }
		[NotMapped]
		public IGTEnrolmentConfigDto IGTEnrolmentConfig { get; set; }
		public string OriginatedFrom
		{
			get
			{
				return MobileRegID == null ? "Website" : "Mobile Application";
			}
		}
	}
}

