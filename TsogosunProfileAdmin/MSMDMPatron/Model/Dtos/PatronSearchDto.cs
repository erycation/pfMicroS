using System;

namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class PatronSearchDto
    {
        public long? Tsogosunid { get; set; }
        public long PatronID { get; set; }
        public int? Property_Registered { get; set; }
        public string SiteName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string FIC_IDNumber { get; set; }
        public string CellNumber { get; set; }
        public int CustomerRank { get; set; }
        public string CustomerTier { get; set; }
        public string ProfileStatus { get; set; }
        public DateTime? LastPlayDate { get; set; }
        public string IdentityNumber
        {
            get
            {
                return FIC_IDNumber;
            }
        }
    }
}
