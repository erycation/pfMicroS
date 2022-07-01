
using System;
using System.ComponentModel.DataAnnotations.Schema;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails
{
    public class ConfirmedPatronDetailsDto : PatronDetailsInfo
    {

        public long Id { get; set; }
        public long? WebSiteID { get; set; }
        public int Rating { get; set; }
        public Guid? MobileRegID { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Occupation { get; set; }
        public string EmailAddress { get; set; }
        public int NationalityID { get; set; }
        public string Nationality { get; set; }
        public string Notes { get; set; }
        public bool? ILikePromotions { get; set; }
        public bool? IsOnHold { get; set; }
        public bool? IsConfirmed { get; set; }
        public string ConfirmedBy { get; set; }//AdminUserName
        public DateTime? DateConfirmed { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Area { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string ProvDescription { get; set; }
        public string IDPassImage { get; set; }
        public string IDPassCountry { get; set; }
        [NotMapped]
        public int? SiteID { get; set; }
        public long? PcId { get; set; }
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
