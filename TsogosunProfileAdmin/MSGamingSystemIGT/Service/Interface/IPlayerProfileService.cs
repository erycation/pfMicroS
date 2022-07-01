

using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.MSGamingSystemIGT.Model.Request;

namespace tsogosun.com.MSGamingSystemIGT.Service.Interface
{
    public interface IPlayerProfileService
    {
        ResponsePlayerProfile GetPlayerProfileByPatronNo(RequestPlayerProfile requestPlayerProfile);
        ResponsePlayerProfile AddPlayerProfile(RequestAddUpdatePlayerProfile requestAddUpdatePlayerProfile);
        ResponsePlayerProfile UpdatePlayerProfile(RequestAddUpdatePlayerProfile requestAddUpdatePlayerProfile, string playerId);
        
    }
}
