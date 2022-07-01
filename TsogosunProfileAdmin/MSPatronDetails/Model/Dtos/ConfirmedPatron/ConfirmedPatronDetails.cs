
using System;
using tsogosun.com.MSPatronDetails.Model.Dtos.PatronInfoDetails;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Model.Dtos.ConfirmedPatron
{
    public class ConfirmedPatronDetails : PatronDetailsInfo
    {
        public long Id { get; set; }
        public long? WebSiteID { get; set; }
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
        public string ConfirmedBy { get; set; }
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
        public int? SiteID { get; set; }
        public bool? PreferredSms { get; set; }
        public bool? PreferredEmail { get; set; }
        public bool? PreferredPhoneCall { get; set; }
        public bool? PreferredPost { get; set; }
        public bool? IsSigningUpForRewards { get; set; }
        public string OriginatedFrom
        {
            get
            {
                return MobileRegID == null ? "Website" : "Mobile Application";
            }
        }
        public string FormatIdPassImage
        {
            get
            {
                return string.IsNullOrEmpty(IDPassImage) ? null : IDPassImage.Compress().ToLower().Contains("data:image/png;base64,") ? IDPassImage.Compress() : $"data:image/png;base64,{IDPassImage.Compress()}";
            }
        }
    }
}
