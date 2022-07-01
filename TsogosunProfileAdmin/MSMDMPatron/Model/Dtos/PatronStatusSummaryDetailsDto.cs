using System;

namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class PatronStatusSummaryDetailsDto
    {
        public long? TsogoSunID { get; set; }
        public DateTime? EnrolmentDate { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string HostedBy { get; set; }
        public int? CustomerRank { get; set; }
        public string CustomerTier { get; set; }
        public string IDNumber { get; set; }
        public string ProfileStatus { get; set; }
        public string IdentityNumber
        {
            get
            {
                return !String.IsNullOrEmpty(IDNumber) ? "(" + IDNumber + ")" : "";
            }
        }
        public string GroupStatus
        {
            get
            {
                return "Rank " + CustomerRank + " " + CustomerTier;
            }
        }
    }
}
