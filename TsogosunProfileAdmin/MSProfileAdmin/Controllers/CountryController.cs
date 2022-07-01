
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("Get/{countryName}")]
        public List<CountryDto> GetCountriesByName(string countryName)
        {
            return _countryService.GetCountriesByName(countryName);
        }

        [HttpGet("GetAll")]
        public List<CountryDto> GetCountries()
        {
            return _countryService.GetCountries();
        }

        [HttpGet("Provinces")]
        public List<ProvinceDto> GetProvinces()
        {
            return _countryService.GetProvinces();
        }

        [HttpGet("Province/Get/{provinceName}")]
        public List<ProvinceDto> GetProvincesByName(string provinceName)
        {
            return _countryService.GetProvincesByName(provinceName);
        }

        [HttpGet("PostalCode/Get/{postalCode}")]
        public List<PostalCodeDto> GetPostalCodesByCode(string postalCode)
        {
            return _countryService.GetPostalCodesByCode(postalCode);
        }

        [HttpGet("City/Get/{cityName}")]
        public List<CityDto> GetCityByName(string cityName)
        {
            return _countryService.GetCityByName(cityName);
        }

        [HttpGet("Suburb/Get/{suburbName}")]
        public List<SuburbDto> GetSuburbByName(string suburbName)
        {
            return _countryService.GetSuburbByName(suburbName);
        }
    }
}

