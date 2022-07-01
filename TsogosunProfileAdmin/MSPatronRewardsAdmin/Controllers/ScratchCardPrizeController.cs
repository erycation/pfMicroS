using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Service.Interface;
using System;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScratchCardPrizeController : ControllerBase
    {

        private readonly IScratchCardPrizeService _scratchCardPrizeService;

        public ScratchCardPrizeController(IScratchCardPrizeService scratchCardPrizeService)
        {
            _scratchCardPrizeService = scratchCardPrizeService;
        }

        [HttpGet("All/{scratchCardUID}/{siteId}")]
        public List<ScratchCardPrizeDto> GetScratchCardPrizeByScratchCardId(Guid scratchCardUID, int siteId)
        {
            return _scratchCardPrizeService.GetScratchCardPrizeByScratchCardId(scratchCardUID, siteId);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ScratchCardPrizeDto scratchCardPrizeDto)
        {
            var responseScratchCadPrize = _scratchCardPrizeService.AddScratchCardPrize(scratchCardPrizeDto);
            return Ok(new { message = responseScratchCadPrize.ReturnMessage });
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ScratchCardPrizeDto scratchCardPrizeDto)
        {
            var responseScratchCadPrize = _scratchCardPrizeService.UpdateScratchCardPrize(scratchCardPrizeDto);
            return Ok(new { message = responseScratchCadPrize.ReturnMessage });
        } 
    }
}
