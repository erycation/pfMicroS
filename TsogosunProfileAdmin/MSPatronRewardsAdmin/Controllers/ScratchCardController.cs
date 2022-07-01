
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
    public class ScratchCardController : ControllerBase
    {

        private readonly IScratchCardService _scratchCardService;

        public ScratchCardController(IScratchCardService scratchCardService)
        {
            _scratchCardService = scratchCardService;
        }

        [HttpGet("All/{siteId}")]
        public List<ScratchCardDto> GetScratchCardsBySiteId(int siteId)
        {
            return _scratchCardService.GetScratchCardsBySiteId(siteId);
        }   

        [HttpGet("{scratchCardUID}/{siteId}")]
        public ScratchCardDto GetScratchCardsByUId(Guid scratchCardUID, int siteId)
        {
            return _scratchCardService.GetScratchCardsByUId(scratchCardUID, siteId);
        }

        [HttpGet]
        [Route("Get/{siteId}/{patronNumber}")]
        public List<PatronScratchCardDto> GetScratchCardsByPatronNumber(int siteId, long patronNumber)
        {
            return _scratchCardService.GetScratchCardsByPatronNumber(siteId, patronNumber);
        }

        [HttpGet("Overview/{siteId}")]
        public List<ScratchCardOverViewDto> GetScratchCardOverViewBySiteId([FromQuery] RequestOverview requestOverview, int siteId)
        {
            return _scratchCardService.GetScratchCardOverViewBySiteId(requestOverview, siteId);
        }

        [HttpGet("Winners/ScratchCard/{siteId}")]
        public List<ScratchCardDto> GetActiveScratchCardsByDateRange([FromQuery] RequestScratchCard requestScratchCard, int siteId)
        {
            return _scratchCardService.GetActiveScratchCardsByDateRange(requestScratchCard, siteId);
        }
        //to be deleted
        [HttpGet("Winners/{scratchCardUID}/{siteId}")]
        public List<ScratchCardWinnersDto> GetScratchWinnersByScratchId(Guid scratchCardUID, int siteId)
        {
            return _scratchCardService.GetScratchWinnersByScratchId(scratchCardUID, siteId);
        }

        [HttpGet("Winners/Report")]
        public List<ScratchCardWinnersDto>GetScratchWinnersReport([FromQuery] RequestScratchCardHeader requestScratchCardHeader)
        {
            return _scratchCardService.GetScratchWinnersReport(requestScratchCardHeader);
        }

        //to be deleted
        [HttpGet("Winners/Report/{scratchCardUID}/{siteId}/{reportType}")]
        public ActionResult Get(Guid scratchCardUID, int siteId, string reportType)
        {
            string dateAndTime = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            dateAndTime = dateAndTime.Replace('/', '-');
            dateAndTime = dateAndTime.Replace(':', '-');
            var returnString = _scratchCardService.GenerateWinnersReportByScratchId(scratchCardUID, siteId, reportType);
            return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, "ScratchCardWinners_" + dateAndTime + "." + reportType);
        }

        [HttpGet("WinnerReport/{reportType}")]
        public ActionResult GetWinnerReport([FromQuery] RequestScratchCardHeader requestScratchCardHeader, string reportType)
        {
            string dateAndTime = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            dateAndTime = dateAndTime.Replace('/', '-');
            dateAndTime = dateAndTime.Replace(':', '-');
            var returnString = _scratchCardService.GeneratScratchCardWinnersReport(requestScratchCardHeader, reportType);
            return File(returnString, System.Net.Mime.MediaTypeNames.Application.Octet, "ScratchCardWinners_" + dateAndTime + "." + reportType);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ScratchCardDto scratchCardDto)
        {
            var responseScratchCard= _scratchCardService.AddScratchCard(scratchCardDto);
            return Ok(new { message = responseScratchCard.ReturnMessage, data = responseScratchCard.ScratchCardUID });
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ScratchCardDto scratchCardDto)
        { 
            var responseScratchCard = _scratchCardService.UpdateScratchCard(scratchCardDto);
            return Ok(new { message = responseScratchCard.ReturnMessage });
        }
    }
}

