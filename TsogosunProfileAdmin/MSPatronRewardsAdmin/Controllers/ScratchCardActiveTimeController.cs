
using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Service.Interface;
using System;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScratchCardActiveTimeController : ControllerBase
    {

        private readonly IScratchCardActiveTimesService _scratchCardActiveTimesService;

        public ScratchCardActiveTimeController(IScratchCardActiveTimesService scratchCardActiveTimesService)
        {
            _scratchCardActiveTimesService = scratchCardActiveTimesService;
        }

        [HttpGet("All/{siteId}/{scratchCardUID}")]
        public List<ScratchCardActiveTimesDto> GetScratchCardActiveTimesBySiteId(int siteId, Guid scratchCardUID)
        {
            return _scratchCardActiveTimesService.GetScratchCardActiveTimesBySiteId(siteId, scratchCardUID);
        }

        [HttpPost("Add/{siteId}")]
        public IActionResult Add([FromBody] RequestAddUpdateScratchCardActiveTime requestAddUpdateScratchCardActiveTime, int siteId)
        {
            var responseScratchCardActiveTimes = _scratchCardActiveTimesService.AddScratchCardActiveTimes(requestAddUpdateScratchCardActiveTime, siteId);
            return Ok(new { message = responseScratchCardActiveTimes.ReturnMessage });
        }

        [HttpPost("Update/{siteId}")]
        public IActionResult Update([FromBody] RequestAddUpdateScratchCardActiveTime requestAddUpdateScratchCardActiveTime, int siteId)
        {
            var responseScratchCardActiveTimes = _scratchCardActiveTimesService.UpdateScratchCardActiveTimes(requestAddUpdateScratchCardActiveTime, siteId);
            return Ok(new { message = responseScratchCardActiveTimes.ReturnMessage });
        }
    }
}
