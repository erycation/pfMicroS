
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Service.Interface;

namespace tsogosun.com.MSMDMPatron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingKPISController : ControllerBase
    {

        private readonly IGamingKPISService _gamingKPISService;

        public GamingKPISController(IGamingKPISService gamingKPISService)
        {
            _gamingKPISService = gamingKPISService;
        }

        [HttpGet("Definitions")]
        public List<GamingKPISDeffinitionDto> GetGamingKPISDeffinition()
        {
            return _gamingKPISService.GetGamingKPISDeffinition();
        }

        [HttpGet("Unit")]
        public GamingKPISUnitDto GetGamingKPISByPatronId([FromQuery] RequestGamingKPISUnit requestGamingKPISUnit)
        {
            return _gamingKPISService.GetGamingKPISByPatronId(requestGamingKPISUnit);
        }

        [HttpGet("Tsg")]
        public GamingKPISTSGDto GetGamingKPISByTsogosunId([FromQuery] RequestGamingKPISTSG requestGamingKPISTSG)
        {
            return _gamingKPISService.GetGamingKPISByTsogosunId(requestGamingKPISTSG);
        }
    }
}
