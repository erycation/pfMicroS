using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class PatronVoucherDto
    {
        public long ID { get; set; }
        public long ParentVoucherID { get; set; }
        public string Vendor { get; set; }
        public string VoucherName { get; set; }
        public string VoucherFullDescription { get; set; }
        public int PointsAmount { get; set; }
        public string BurnPoints { get; set; }
        public int AmountAllowed { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DisplayOn { get; set; }
        public string OfferStatus { get; set; }
        public string TakeupMedium { get; set; }
        public DateTime? DatePrinted { get; set; }
        public string OfferAvailability { get; set; }
        public long? OtpNumber { get; set; }
       
    }
}

