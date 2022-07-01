using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class PatronFreePlayDto
    {
        public long ID { get; set; }
        public string Vendor { get; set; }
        public string XtraCreditFullDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cost { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string RedemptionType { get; set; }
        public string MobileImageURL { get; set; }
        public string OfferStatus { get; set; }
        public string TakeupMedium { get; set; }
        public DateTime? DateReceived { get; set; }
        public string LoadedTo { get; set; }
        public string OfferAvailability { get; set; }
        public long? OtpNumber { get; set; }

    }
}
