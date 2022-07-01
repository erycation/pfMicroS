

using tsogosun.com.MSGamingSystemIGT.Shared;

namespace tsogosun.com.MSGamingSystemIGT.Model.Request
{
    public class RequestPlayerRanking : HasSiteId
    {
        public string PlayerID { set; get; }
        public string SiteDescription { set; get; }
        public string RankingID { set; get; }
        public string RankingDescription { set; get; }
    }
}
