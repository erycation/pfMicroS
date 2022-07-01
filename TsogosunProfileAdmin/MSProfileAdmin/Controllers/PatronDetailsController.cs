
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronDetailsController : ControllerBase
    {
        private readonly IPatronDetailsService _patronDetailService;

        public PatronDetailsController(IPatronDetailsService patronDetailService)
        {
            _patronDetailService = patronDetailService;
        }

        [HttpGet("Get")]
        public List<PatronDetailsDto> GetPatronDetailsBySiteId([FromQuery] RequestPatronDetails requestPatronDetails)
        {
            return _patronDetailService.GetPatronDetailsBySiteId(requestPatronDetails);
        }

        [HttpPost("Update/Status")]
        public IActionResult UpdatePatronDetailsStatus([FromBody] RequestUpdatePatronStatus requestUpdatePatronStatus)
        {
            var responsePatronDetails = _patronDetailService.UpdatePatronDetailsStatus(requestUpdatePatronStatus);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }

        [HttpGet("Info/Get/{userId}/{siteId}")]
        public PatronsDetailsInfoDto GetPatronDetailByUserId(int userId, int siteId)
        {
            return _patronDetailService.GetPatronDetailByUserId(userId, siteId);
        }

        [HttpPost("Update/Info")]
        public IActionResult UpdatePatronDetails([FromBody] PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailService.UpdatePatronDetails(patronsDetailsInfoDto);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }

        [HttpPost("Update/Address")]
        public IActionResult UpdatePatronAddress([FromBody] PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailService.UpdatePatronAddress(patronsDetailsInfoDto);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }

        [HttpGet("Confirmed/Get/{userId}/{siteId}")]
        public ConfirmedPatronDetailsDto GetConfirmedPatronDetailByUserId(long userId, int siteId)
        {
            return _patronDetailService.GetConfirmedPatronDetailByUserId(userId, siteId);
        }
    }
}
