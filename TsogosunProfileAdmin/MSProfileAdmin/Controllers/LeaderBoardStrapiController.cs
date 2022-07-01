using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardStrapiController : ControllerBase
    {

        private readonly ILeaderBoardStrapiService _leaderBoardStrapiService;

        public LeaderBoardStrapiController(ILeaderBoardStrapiService leaderBoardStrapiService)
        {

            _leaderBoardStrapiService = leaderBoardStrapiService;

        }

        [HttpGet("GetAll/{unitId}")]
        public async Task<List<LeaderBoardStrapi>> GetLeaderBoardStrapiContentsByUnitId(int unitId)
        {

            return await _leaderBoardStrapiService.GetLeaderBoardStrapiContentsByUnitId(unitId);

        }
    }
}
