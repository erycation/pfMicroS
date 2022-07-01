using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class CountryRepository : ICountryRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public CountryRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<CountryDto> GetCountriesByName(string countryName)
        {
            return _dbContext.CountryDtos.FromSqlRaw("pPDETAILS_GetCountries @CountryName",
                                                                       new SqlParameter("@CountryName", countryName)).ToList();
        }
        public List<CountryDto> GetCountries()
        {
            return _dbContext.CountryDtos.FromSqlRaw("pPDETAILS_GetCountries").ToList();
        }
      
        public List<ProvinceDto> GetProvincesByName(string provinceName)
        {
            return _dbContext.ProvinceDtos.FromSqlRaw("pPDETAILS_GetProvincesByName @ProvinceName",
                                                                       new SqlParameter("@ProvinceName", provinceName)).ToList();
        }

        public List<ProvinceDto> GetProvinces()
        {
            return _dbContext.ProvinceDtos.FromSqlRaw("pPDETAILS_GetProvinces").ToList();
        }

        public List<PostalCodeDto> GetPostalCodesByCode(string postalCode)
        {
            return _dbContext.PostalCodeDtos.FromSqlRaw("pPDETAILS_GetPostalCodesByCode @Code",
                                                                       new SqlParameter("@Code", postalCode)).ToList();
        }

        public List<CityDto> GetCityByName(string cityName)
        {
            return _dbContext.CityDtos.FromSqlRaw("pPDETAILS_GetCityByName @City",
                                                                       new SqlParameter("@City", cityName)).ToList();
        }

        public List<SuburbDto> GetSuburbByName(string suburbName)
        {
            return _dbContext.SuburbDtos.FromSqlRaw("pPDETAILS_GetSuburbByName @SuburbName",
                                                                       new SqlParameter("@SuburbName", suburbName)).ToList();
        }

    }
}
