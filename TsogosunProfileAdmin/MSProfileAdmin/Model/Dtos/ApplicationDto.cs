

using System.Collections.Generic;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class ApplicationDto
    {
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string WebsiteRoute { get; set; }
        public bool IsApplicationMenuItem { get; set; }
        public string IconName { get; set; }
        public List<SectionDto> Sections { get; set; }
    }
}

