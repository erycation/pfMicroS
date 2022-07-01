
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Service.Interface;

namespace tsogosun.com.MSMDMPatron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingPointsController : ControllerBase
    {

        private readonly IGamingPointsService _gamingPointsService;

        public GamingPointsController(IGamingPointsService gamingPointsService)
        {
            _gamingPointsService = gamingPointsService;
        }

        [HttpGet("Get/TSG/{tsogosunID}")]
        public GamingPointsTSGDto GetTSGGamingPointsByTsogosunId(long tsogosunID)
        {
            return _gamingPointsService.GetTSGGamingPointsByTsogosunId(tsogosunID);
        }

        [HttpGet("Get/Unit/{siteId}/{patronNumber}")]
        public GamingPointsUnitDto GetUnitGamingPointsByTsogosunId(long siteId, long patronNumber)
        {
            return _gamingPointsService.GetUnitGamingPointsByTsogosunId(siteId, patronNumber);
        }
    }
}
