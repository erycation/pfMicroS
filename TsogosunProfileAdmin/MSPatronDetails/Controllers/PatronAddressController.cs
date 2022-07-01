
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;
using tsogosun.com.MSPatronDetails.Service.Interface;

namespace tsogosun.com.MSPatronDetails.Controllers
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
