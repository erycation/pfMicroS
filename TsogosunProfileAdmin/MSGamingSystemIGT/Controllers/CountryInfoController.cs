
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;

namespace tsogosun.com.MSGamingSystemIGT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryInfoController : ControllerBase
    {

        private readonly ICountryInfoService _countryInfoService;
        public CountryInfoController(ICountryInfoService countryInfoService)
        {
            _countryInfoService = countryInfoService;
        }

        [HttpPost("CountryName")]
        public ResponseIGTCountryInfo GetCountryByName(RequestCountryInfoByNameIGT requestCountryInfoByNameIGT)
        {
            return _countryInfoService.GetCountryInfo(requestCountryInfoByNameIGT);
        }

        [HttpPost("ZipCode")]
        public ResponseIGTZipCode GetZipCodeDetails(RequestZipCodeIGT requestZipCodeIGT)
        {
            return _countryInfoService.GetZipCodeDetails(requestZipCodeIGT);
        }
    }
}
