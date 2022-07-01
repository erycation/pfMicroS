
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;

namespace tsogosun.com.MSGamingSystemIGT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerInfoIGTController : ControllerBase
    {

        private readonly IIGTPlayerInfoService _iIGTPlayerInfoService;
        public PlayerInfoIGTController(IIGTPlayerInfoService iIGTPlayerInfoService)
        {
            _iIGTPlayerInfoService = iIGTPlayerInfoService;
        }

        [HttpPost("SSN")]
        public ResponseIGTPlayerInfo GetIGTPlayerInfoBySSN([FromBody] RequestPlayerInfoBySSNIGT requestPlayerInfoBySSNIGT)
        {
            return _iIGTPlayerInfoService.GetIGTPlayerInfoBySSN(requestPlayerInfoBySSNIGT);
        }

        [HttpPost("Name")]
        public ResponseIGTPlayerInfo GetIGTPlayerInfoByName([FromBody] RequestPlayerInfoByNameIGT requestPlayerInfoByNameIGT)
        {
            return _iIGTPlayerInfoService.GetIGTPlayerInfoByName(requestPlayerInfoByNameIGT);
        }

        [HttpPost("Player")]
        public ResponseIGTPlayerInfo GetIGTPlayerInfoByPlayerID([FromBody]RequestPlayerInfoByPlayerIDIGT requestPlayerInfoByPlayerIDIGT)
        {
            return _iIGTPlayerInfoService.GetIGTPlayerInfoByPlayerID(requestPlayerInfoByPlayerIDIGT);
        }
    }
}
