
using System.Collections.Generic;
using tsogosun.com.GamingSystemIGT.Model.UserDto;

namespace tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto
{
    public class PlayerProfile
    {
        public string DateofBirth { set; get; }
        public string Anniversary { set; get; }
        public string CreditAccount { set; get; }
        public string Gender { set; get; }
        public string PINLocked { set; get; }
        public string WebEnabled { set; get; }
        public string Nationality { set; get; }
        public string PipPep { set; get; }
        public string Exempt { set; get; }
        public string Attraction { set; get; }
        public string Affiliation { set; get; }
        public string DateEnrolled { set; get; }
        public Name Name { set; get; }        
        public User EnrolledBy { set; get; }
        public Status Status { set; get; }
        public Employment Employment { set; get; }
        public List<Languages> Languages { set; get; }
        public List<Address> Addresses { set; get; }
        public List<PhoneNumber> PhoneNumbers { set; get; }
        public List<Identification> Identifications { set; get; }
        public List<Email> Emails { set; get; }
        public List<CardNumber> CardNumbers { set; get; }
        public List<Restriction> PlayerRestrictions { set; get; }
        public List<Interest> Interests { set; get; }
        public List<SiteInfo> SiteParameters { set; get; }
    
    }
}
