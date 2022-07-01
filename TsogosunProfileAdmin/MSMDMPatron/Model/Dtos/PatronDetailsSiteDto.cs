using System;

namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class PatronDetailsSiteDto
    {
        public int? DimPatronID { get; set; }
        public string HostedBy { get; set; }
        public long PatronID { get; set; }
        public int? Property_Registered { get; set; }
        public int CustomerRank { get; set; }
        public string CustomerTier { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public DateTime? DOB { get; set; }
        public string IDNumber { get; set; }
        public string IDDescription { get; set; }
        public DateTime? IDExpiryDate { get; set; }
        public string IDCountry { get; set; }
        public DateTime? IDVerificationDate { get; set; }
        public string PassportNumber { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PipPep { get; set; }
        public string Employer { get; set; }
        public string Occupation { get; set; }
        public string AffiliationDescription { get; set; }
        public string LanguagePreference { get; set; }
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string PhonePreffered { get; set; }
        public string HomeEmail { get; set; }
        public string OfficeEmail { get; set; }
        public string EmailPreffered { get; set; }
        public string PhyAddressLine1 { get; set; }
        public string PhyAddressLine2 { get; set; }
        public string PhyAddressSuburb { get; set; }
        public string PhyAddressCity { get; set; }
        public string PhyAddressState { get; set; }
        public string PhyAddressCountry { get; set; }
        public string PhyAddressZipCode { get; set; }
        public string ProfileStatus { get; set; }
        public string AllowComms { get; set; }
        public string AllowSMS { get; set; }
        public string AllowEmail { get; set; }
        public string AllowPhone { get; set; }
        public string AllowMail { get; set; }
        public long? MDM_CheckSum { get; set; }
        public DateTime? LastPlayDate { get; set; }
        public DateTime? EnrolmentDate { get; set; }
        public string BanComment { get; set; }
        public DateTime? BanExpirationDate { get; set; }
        public DateTime? BanIssuedDate { get; set; }
        public string BanLongDescription { get; set; }
        public string BanShortDescription { get; set; }
        public string BanTypeDescription { get; set; }
        public string IdentityNumber
        {
            get
            {
                return !String.IsNullOrEmpty(IDNumber) ? IDNumber : PassportNumber;
            }
        }
        public string DateOfBirth
        {
            get
            {
                return !String.IsNullOrEmpty(DOB.ToString()) ? DOB?.ToString("yyyy-MM-dd") : "";
            }
        }
    }
}
