
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;

namespace tsogosun.com.MSGamingSystemIGT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerProfileController : ControllerBase
    {

        private readonly IPlayerProfileService _playerProfileService;
        public PlayerProfileController(IPlayerProfileService playerProfileService)
        {
            _playerProfileService = playerProfileService;
        }

        [HttpPost("Get")]
        public ResponsePlayerProfile GetPlayerProfile([FromBody] RequestPlayerProfile requestPlayerProfile)
        {
            return _playerProfileService.GetPlayerProfileByPatronNo(requestPlayerProfile);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] RequestAddUpdatePlayerProfile requestAddUpdatePlayerProfile)
        {
            var responseUser = _playerProfileService.AddPlayerProfile(requestAddUpdatePlayerProfile);
            return Ok(new { message = $"{responseUser.PlayerProfileBody?.PlayerProfile?.Name?.FirstName} {responseUser.PlayerProfileBody?.PlayerProfile?.Name?.LastName} Patron Number {responseUser.PlayerID} is successfully created." });
        }

        [HttpPost("Update/{playerId}")]
        public IActionResult Update([FromBody] RequestAddUpdatePlayerProfile requestAddUpdatePlayerProfile, string playerId)
        {
            var responseUser = _playerProfileService.UpdatePlayerProfile(requestAddUpdatePlayerProfile, playerId);
            return Ok(new { message = $"Patron No {responseUser.PlayerID} is successfully updated." });
        }
    }
}
