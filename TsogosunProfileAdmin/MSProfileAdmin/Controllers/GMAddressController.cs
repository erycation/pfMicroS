using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GMAddressController : ControllerBase
    {
        private readonly IGMAddressService _igmAddressService;

        public GMAddressController(IGMAddressService igmAddressService)
        {
            _igmAddressService = igmAddressService;
        }

        [HttpGet("Country/{siteId}")]
        public List<GMCountryDto> GetCountriesBySiteId(int siteId)
        {
            return _igmAddressService.GetCountriesBySiteId(siteId);
        }

        [HttpGet("Province/{siteId}/{countryId}")]
        public List<GMProvinceDto> GetProvincesBySiteId(int siteId, int countryId)
        {
            return _igmAddressService.GetProvincesBySiteId(siteId, countryId);
        }

        [HttpGet("Address")]
        public List<GMAddressDto> GetAddressByProvinceId([FromQuery] RequestGMAddress requestGMAddress)
        {
            return _igmAddressService.GetAddressByProvinceId(requestGMAddress);
        }
    }
}
