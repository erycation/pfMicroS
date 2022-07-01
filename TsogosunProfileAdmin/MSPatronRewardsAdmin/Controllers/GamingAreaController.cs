
using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingAreaController : ControllerBase
    {
        private readonly IGamingAreaService _gamingAreaService;

        public GamingAreaController(IGamingAreaService gamingAreaService)
        {
            _gamingAreaService = gamingAreaService;
        }

        [HttpGet("All/{siteId}")]
        public List<GamingAreaDto> GetAllGamingAreaBySiteId(int siteId)
        {
            return _gamingAreaService.GetAllGamingAreaBySiteId(siteId);
        }
    }
}
