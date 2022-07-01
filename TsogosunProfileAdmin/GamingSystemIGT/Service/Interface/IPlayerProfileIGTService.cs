

using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.GamingSystemIGT.Model.Request;

namespace tsogosun.com.GamingSystemIGT.Service.Interface
{
    public interface IPlayerProfileIGTService
    {
        ResponsePlayerProfile GetPlayerProfileByPatronNo(RequestPlayerProfileIGT requestPlayerProfile);
        ResponsePlayerProfile AddUpdatePlayerProfile(RequestAddUpdatePlayerProfileIGT requestAddUpdatePlayerProfile);
        ResponsePlayerProfile UpdatePlayerProfile(RequestAddUpdatePlayerProfileIGT requestAddUpdatePlayerProfile, string playerId);

    }
}
