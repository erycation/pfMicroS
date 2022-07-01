
using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeTypeController : ControllerBase
    {

        private readonly IPrizeTypeService _prizeTypeService;

        public PrizeTypeController(IPrizeTypeService prizeTypeService)
        {
            _prizeTypeService = prizeTypeService;
        }

        [HttpGet("All/{siteId}")]
        public List<PrizeTypeDto> GetPrizeTypesBySiteId(int siteId)
        {
            return _prizeTypeService.GetPrizeTypesBySiteId(siteId);
        }
    }
}
