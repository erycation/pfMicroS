

using tsogosun.com.GamingSystemIGT.Model.UserDto;

namespace tsogosun.com.GamingSystemIGT.Model
{
    public class SiteInfo
    {
        public string SiteID { set; get; }
        public string PointBalance { set; get; }
        public Ranking Ranking { set; get; }        
        public User Host { set; get; }        

    }
}
