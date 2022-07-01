using Microsoft.AspNetCore.Mvc;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Service.Interface;

namespace tsogosun.com.MSPatronDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GMSPatronDetailsController : ControllerBase
    {

        private readonly IGMSPatronDetailsService _gmsPatronDetailsService;

        public GMSPatronDetailsController(IGMSPatronDetailsService gmsPatronDetailsService)
        {
            _gmsPatronDetailsService = gmsPatronDetailsService;
        }

        [HttpPost("Add")]
        public IActionResult AddGMSPatronDetails([FromBody] GMSPatronDetails gmsPatronDetails)
        {
            var responsePatronDetails = _gmsPatronDetailsService.AddGMSPatronDetails(gmsPatronDetails);
            return Ok(new { message = responsePatronDetails.ReturnMessage });
        }
    }
}
