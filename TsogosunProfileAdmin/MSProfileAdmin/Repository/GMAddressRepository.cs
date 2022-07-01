

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;
using tsogosun.com.MSProfileAdmin.Model.Request;
using System;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class GMAddressRepository : IGMAddressRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public GMAddressRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<GMCountryDto> GetCountriesBySiteId(int siteId)
        {
            return _dbContext.GMCountryDtos.FromSqlRaw("pSEL_GMCountriesBySiteId @SiteId",
                                                                        new SqlParameter("@SiteId", siteId)).ToList();
        }

        public List<GMProvinceDto> GetProvincesBySiteId(int siteId, int countryId)
        {
            return _dbContext.GMProvinceDtos.FromSqlRaw("pSEL_GMProvincesBySiteId @SiteId, @CountryId",
                                                                       new SqlParameter("@SiteId", siteId),
                                                                       new SqlParameter("@CountryId", countryId)).ToList();
        }

        public List<GMAddressDto> GetAddressByProvinceId(RequestGMAddress requestGMAddress)
        {
            return _dbContext.GMAddressDtos.FromSqlRaw("pSEL_GMPostalCodes @SiteId, @ProvinceId , @Town, @Suburb, @PostalCode",
                                                                      new SqlParameter("@SiteId", requestGMAddress.SiteId),
                                                                       new SqlParameter("@ProvinceId", requestGMAddress.ProvinceId),
                                                                        new SqlParameter("@Town", string.IsNullOrEmpty(requestGMAddress.Town) ? DBNull.Value : requestGMAddress.Town),
                                                                         new SqlParameter("@Suburb", string.IsNullOrEmpty(requestGMAddress.Suburb) ? DBNull.Value : requestGMAddress.Suburb),
                                                                          new SqlParameter("@PostalCode", string.IsNullOrEmpty(requestGMAddress.PostalCode) ? DBNull.Value : requestGMAddress.PostalCode)).ToList();

        }
    }
}
