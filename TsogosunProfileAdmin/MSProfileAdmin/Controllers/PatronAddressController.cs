
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronAddressController : ControllerBase
    {

        private readonly IPatronAddressService _patronAddressService;

        public PatronAddressController(IPatronAddressService patronAddressService)
        {
            _patronAddressService = patronAddressService;
        }

        [HttpGet("GetAll")]
        public List<PatronAddressSearchDto> GetPatronAddressSearch([FromQuery]RequestPatronAddress requestPatronAddress)
        {
            return _patronAddressService.GetPatronAddressSearch(requestPatronAddress);
        }
    }
}
