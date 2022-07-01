
using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {

        private readonly ILeaderBoardService _leaderBoardService;

        public LeaderBoardController(ILeaderBoardService leaderBoardService)
        {
            _leaderBoardService = leaderBoardService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] RequestAddUpdateLeaderBoard requestAddUpdateLeaderBoard)
        {
            var responseLeaderBoard = _leaderBoardService.AddLeaderBoard(requestAddUpdateLeaderBoard);
            return Ok(new { message = responseLeaderBoard .ReturnMessage, data = responseLeaderBoard.PromotionID});
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] RequestAddUpdateLeaderBoard requestAddUpdateLeaderBoard)
        {
            var responseLeaderBoard = _leaderBoardService.UpdateLeaderBoard(requestAddUpdateLeaderBoard);
            return Ok(new { message = responseLeaderBoard.ReturnMessage});
        }

        [HttpGet("All/{siteId}")]
        public List<LeaderBoardPromotionDto> GetLeaderBoardPromotionsBySiteId(int siteId, [FromQuery] RequestLeaderBoard requestLeaderBoard)
        {
            return _leaderBoardService.GetLeaderBoardPromotionsBySiteId(siteId, requestLeaderBoard);
        }

        [HttpGet("Get/{siteId}/{promotionId}")]
        public LeaderBoardPromotionDto GetLeaderBoardByPromotionId(int siteId, int promotionId)
        {
            return _leaderBoardService.GetLeaderBoardByPromotionId(siteId, promotionId);
        }

        [HttpGet("Patron/{siteId}/{patronNo}")]
        public List<LeaderBoardPatronDto> GetLeaderBoardByPatronNumber(int siteId, long patronNo)
        {
            return _leaderBoardService.GetLeaderBoardByPatronNumber(siteId, patronNo);
        }
    }
}
