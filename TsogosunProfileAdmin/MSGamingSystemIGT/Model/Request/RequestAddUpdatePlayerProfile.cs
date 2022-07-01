

using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.MSGamingSystemIGT.Shared;

namespace tsogosun.com.MSGamingSystemIGT.Model.Request
{
    public class RequestAddUpdatePlayerProfile : HasSiteId
    {

        public PlayerProfile PlayerProfile { set; get; }

    }
}
