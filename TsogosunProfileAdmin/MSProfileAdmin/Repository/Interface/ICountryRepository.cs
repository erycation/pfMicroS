
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface ICountryRepository
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
