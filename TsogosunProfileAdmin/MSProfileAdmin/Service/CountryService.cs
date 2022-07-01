
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class CountryService : ICountryService
    {

        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<CountryDto> GetCountriesByName(string countryName)
        {
            return _countryRepository.GetCountriesByName(countryName);
        }

        public List<CountryDto> GetCountries()
        {
            return _countryRepository.GetCountries();
        }       

        public List<ProvinceDto> GetProvincesByName(string provinceName)
        {
            return _countryRepository.GetProvincesByName(provinceName);
        }

        public List<ProvinceDto> GetProvinces()
        {
            return _countryRepository.GetProvinces();
        }

        public List<PostalCodeDto> GetPostalCodesByCode(string postalCode)
        {
            return _countryRepository.GetPostalCodesByCode(postalCode);
        }

        public List<CityDto> GetCityByName(string cityName)
        {
            return _countryRepository.GetCityByName(cityName);
        }

        public List<SuburbDto> GetSuburbByName(string suburbName)
        {
            return _countryRepository.GetSuburbByName(suburbName);
        }
    }
}