

using System.Collections.Generic;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class SectionDto
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public bool IsSectionMenuItem { get; set; }
        public string WebsiteSectionRoute { get; set; }
        public string ReferenceName { get; set; }
        public string SectionIconName { get; set; }
        public List<SiteDto> Sites { get; set; }
    }
}
