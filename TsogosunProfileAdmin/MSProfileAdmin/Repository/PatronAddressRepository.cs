using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;
using tsogosun.com.MSProfileAdmin.Model.Request;
using System;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class PatronAddressRepository : IPatronAddressRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public PatronAddressRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<PatronAddressSearchDto> GetPatronAddressSearch(RequestPatronAddress requestPatronAddress)
        {
            return _dbContext.PatronAddressSearchDtos.FromSqlRaw("pPDETAILS_GetPatronAddressBySearch @City, @CountryName , @Province, @Suburb, @PostalCode",
                                                                       new SqlParameter("@City", string.IsNullOrEmpty(requestPatronAddress.City) ? DBNull.Value : requestPatronAddress.City),
                                                                        new SqlParameter("@CountryName", string.IsNullOrEmpty(requestPatronAddress.CountryName) ? DBNull.Value : requestPatronAddress.CountryName),
                                                                         new SqlParameter("@Province", string.IsNullOrEmpty(requestPatronAddress.Province) ? DBNull.Value : requestPatronAddress.Province),
                                                                          new SqlParameter("@Suburb", string.IsNullOrEmpty(requestPatronAddress.Suburb) ? DBNull.Value : requestPatronAddress.Suburb),
                                                                           new SqlParameter("@PostalCode", string.IsNullOrEmpty(requestPatronAddress.PostalCode) ? DBNull.Value : requestPatronAddress.PostalCode)).ToList();
        }
    }
}
