

using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;

namespace tsogosun.com.GamingSystemIGT.Service.Interface
{
    public interface IPlayerInfoIGTService
    {
        ResponseIGTPlayerInfo GetIGTPlayerInfoByPlayerID(RequestIGTPlayerInfoByPlayerID requestPlayerInfoByPlayerID);
        ResponseIGTPlayerInfo GetIGTPlayerInfoBySSN(RequestIGTPlayerInfoBySSN requestPlayerInfoBySSN);
        ResponseIGTPlayerInfo GetIGTPlayerInfoByName(RequestIGTPlayerInfoByName requestPlayerInfoByName);
    }
}
