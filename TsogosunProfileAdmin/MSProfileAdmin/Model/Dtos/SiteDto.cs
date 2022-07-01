
namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class SiteDto
    {
        public SiteDto(Site site)
        {
            SiteID = site.SiteID;
            SiteName = site.SiteName;
            SiteFullName = site.SiteFullName;
        }

        public SiteDto()
        {

        }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteFullName { get; set; }
        
    }
}
