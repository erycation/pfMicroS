using System;

namespace tsogosun.com.MSPatronDetails.Model.Dtos
{
    public class ApprovedUserDetailsDto
    {
        public int SiteId { get; set; }
        public long UserId { get; set; }
        public string IdpassportNO { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Rating { get; set; }
        public string RecordStatus { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string ConfirmedBy { get; set; }
    }
}
