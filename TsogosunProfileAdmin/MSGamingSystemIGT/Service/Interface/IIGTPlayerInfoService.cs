
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;
using tsogosun.com.MSGamingSystemIGT.Model.Request;

namespace tsogosun.com.MSGamingSystemIGT.Service.Interface
{
    public interface IIGTPlayerInfoService
    {
        ResponseIGTPlayerInfo GetIGTPlayerInfoByPlayerID(RequestPlayerInfoByPlayerIDIGT requestPlayerInfoByPlayerIDIGT);
        ResponseIGTPlayerInfo GetIGTPlayerInfoBySSN(RequestPlayerInfoBySSNIGT requestPlayerInfoBySSNIGT);
        ResponseIGTPlayerInfo GetIGTPlayerInfoByName(RequestPlayerInfoByNameIGT requestPlayerInfoByNameIGT);
    }
}
