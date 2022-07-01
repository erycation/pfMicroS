using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;
using tsogosun.com.MSPatronDetails.Service.Interface;

namespace tsogosun.com.MSPatronDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronDetailsController : ControllerBase
    {

        private readonly IPatronDetailsService _patronDetailsService;

        public PatronDetailsController(IPatronDetailsService patronDetailsService)
        {
            _patronDetailsService = patronDetailsService;
        }

        [HttpGet("Get")]
        public List<PatronDetailsDto> GetPatronDetailsBySiteId([FromQuery] RequestPatronDetails requestPatronDetails)
        {
            return _patronDetailsService.GetPatronDetailsBySiteId(requestPatronDetails);
        }

        [HttpPost]
        [Route("Update/Status")]
        public IActionResult UpdatePatronDetailsStatus([FromBody] RequestUpdatePatronStatus requestUpdatePatronStatus)
        {
            var responsePatronDetails = _patronDetailsService.UpdatePatronDetailsStatus(requestUpdatePatronStatus);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }

        //to be deleted
        [HttpGet]
        [Route("Info/Get/{userId}/{siteId}")]
        public PatronsDetailsInfoDto GetPatronDetailByUserId(int userId, int siteId)
        {
            return _patronDetailsService.GetPatronDetailByUserId(userId, siteId);
        }

        [HttpGet("Unconfirmed/gamesmart/{userId}")]
        public UnconfirmedGMSPatronDetailsInfoDto GetUnconfirmedGMSPatronDetailsInfoByUserId(int userId)
        {
            return _patronDetailsService.GetUnconfirmedGMSPatronDetailsInfoByUserId(userId);
        }

        [HttpGet("Unconfirmed/IGT/{userId}")]
        public UnconfirmedIGTPatronDetailsInfoDto GetUnconfirmedIGTPatronDetailsInfoByUserId(int userId)
        {
            return _patronDetailsService.GetUnconfirmedIGTPatronDetailsInfoByUserId(userId);
        }

        [HttpPost("Update/Unconfirmed/Gamesmart")]
        public IActionResult UpdateUnconfirmedGMSPatronDetails([FromBody] UnconfirmedGMSPatronDetailsInfoDto unconfirmedGMSPatronDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsService.UpdateUnconfirmedGMSPatronDetails(unconfirmedGMSPatronDetailsInfoDto);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }

        [HttpPost("Update/Unconfirmed/Igt")]
        public IActionResult UpdateUnconfirmedIGTPatronDetails([FromBody] UnconfirmedIGTPatronDetailsInfoDto unconfirmedIGTPatronDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsService.UpdateUnconfirmedIGTPatronDetails(unconfirmedIGTPatronDetailsInfoDto);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }


       




        [HttpPost("Update/Info")]
        public IActionResult UpdatePatronDetails([FromBody] PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsService.UpdatePatronDetails(patronsDetailsInfoDto);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }

        [HttpPost("Update/Address")]
        public IActionResult UpdatePatronAddress([FromBody] PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsService.UpdatePatronAddress(patronsDetailsInfoDto);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }
        //IGT
        [HttpGet("Confirmed/Igt/{userId}")]
        public IGTConfirmedPatronDetailsDto GetConfirmedPatronDetailFromIGTByUserId(long userId)
        {
            return _patronDetailsService.GetConfirmedPatronDetailFromIGTByUserId(userId);
        }

        [HttpGet("Confirmed/Gamesmart/{userId}/{siteId}")]
        public GMSConfirmedPatronDetailsDto GetConfirmedPatronDetailFromGamesmartByUserId(long userId, int siteId)
        {
            return _patronDetailsService.GetConfirmedPatronDetailFromGamesmartByUserId(userId, siteId);
        } 

        [HttpGet("Approved/GetAll/{siteId}")]
        public List<ApprovedUserDetailsDto> GetApprovedUserDetailsBySiteId(int siteId)
        {
            return _patronDetailsService.GetApprovedUserDetailsBySiteId(siteId);
        }

        [HttpPost("Gaming/Confirm/Status")]
        public IActionResult Add([FromBody] ConfirmPlayerToSubmitGamingDto confirmPlayerToSubmitGamingDto)
        {
            var responsePlayer = _patronDetailsService.ConfirmPlayerStatusAfterSubmitToGaming(confirmPlayerToSubmitGamingDto);
            return Ok(new { message = responsePlayer.ReturnMessage});
        }
    }
}
