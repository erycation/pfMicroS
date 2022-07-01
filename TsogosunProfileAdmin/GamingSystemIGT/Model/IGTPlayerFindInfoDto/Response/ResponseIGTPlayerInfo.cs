
using System.Collections.Generic;
using tsogosun.com.GamingSystemIGT.Response;

namespace tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response
{
    public class ResponseIGTPlayerInfo
    {
        public Error Error { set; get; }
        public List<PlayerFindInfoDto> playersInfoDto { set; get; }
       
    }
}
