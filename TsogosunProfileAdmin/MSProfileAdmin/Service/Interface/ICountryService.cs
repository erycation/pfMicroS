
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface ICountryService
    {

        List<CountryDto> GetCountriesByName(string countryName);
        List<CountryDto> GetCountries();
        List<ProvinceDto> GetProvinces();
        List<ProvinceDto> GetProvincesByName(string provinceName);
        List<PostalCodeDto> GetPostalCodesByCode(string postalCode);
        List<CityDto> GetCityByName(string cityName);
        List<SuburbDto> GetSuburbByName(string suburbName);
    }
}
