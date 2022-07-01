
using tsogosun.com.GamingSystemIGT.Shared.Utils;

namespace tsogosun.com.GamingSystemIGT.Model.PlayerRankingDto
{
    public class RequestPlayerRankingIGT : InterfaceParameter
    {
        public string PlayerID { set; get; }
        public string SiteDescription { set; get; }
        public string RankingID { set; get; }
        public string RankingDescription { set; get; }

    }
}
