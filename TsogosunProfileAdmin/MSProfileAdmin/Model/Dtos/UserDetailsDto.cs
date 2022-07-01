

using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class UserDetailsDto
    {
        public int ReturnCode { get; set; }
        public string RetunMessage { get; set; }
        public int UserID { get; set; }
        public Guid UserSessionID { get; set; }        
        public string Username { get; set; }
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public string IconName { get; set; }
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string SiteName { get; set; }        
        public int SiteID { get; set; }
        public string SiteFullName { get; set; }
        public string WebsiteRoute { get; set; }
        public bool IsApplicationMenuItem { get; set; }
        public bool IsSectionMenuItem { get; set; }             
        public string WebsiteSectionRoute { get; set; }
        public string ReferenceName { get; set; }
        public string SectionIconName { get; set; }

    }
}


