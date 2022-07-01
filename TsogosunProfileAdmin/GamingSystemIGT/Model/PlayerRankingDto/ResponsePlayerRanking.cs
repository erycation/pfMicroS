

using tsogosun.com.GamingSystemIGT.Response;

namespace tsogosun.com.GamingSystemIGT.Model.PlayerRankingDto
{
    public class ResponsePlayerRanking : Error
    {
        public bool Success { set; get; } = false;
        public string Message { set; get; }

    }
}
