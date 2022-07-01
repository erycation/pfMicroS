
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;

namespace tsogosun.com.MSGamingSystemIGT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RanksController : ControllerBase
    {

        private readonly IPatronRankingService _patronRankingService;
        public RanksController(IPatronRankingService patronRankingService)
        {
            _patronRankingService = patronRankingService;
        }

        [HttpPost("Update")]
        public IActionResult UpdatePlayerRanking([FromBody] RequestPlayerRanking requestPlayerRanking)
        {
            var responsePlayerRanking = _patronRankingService.UpdatePlayerRanking(requestPlayerRanking);
            return Ok(new { message = $"Rank is {responsePlayerRanking.Message} updated" });
        }
    }
}

