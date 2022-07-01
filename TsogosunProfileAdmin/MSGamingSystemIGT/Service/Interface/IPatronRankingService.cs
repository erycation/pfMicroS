

using tsogosun.com.GamingSystemIGT.Model.PlayerRankingDto;
using tsogosun.com.MSGamingSystemIGT.Model.Request;

namespace tsogosun.com.MSGamingSystemIGT.Service.Interface
{
    public interface IPatronRankingService
    {
        ResponsePlayerRanking UpdatePlayerRanking(RequestPlayerRanking requestPlayerRanking);
    }
}
