
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTPatronDetails;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class IGTEnrolmentConfigRepository : IIGTEnrolmentConfigRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public IGTEnrolmentConfigRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions()
        {
            return _dbContext.IGTEnrolmentConfigDtos.FromSqlRaw("pPDETAILS_getIGTEnrolmentConfigurations").ToList();
        }

        public IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId)
        {
            return _dbContext.IGTEnrolmentConfigDtos.FromSqlRaw("pPDETAILS_getIGTEnrolmentConfigBySiteID @UserID ",
                                                           new SqlParameter("@UserID", siteId)).ToList().FirstOrDefault();
        }

        public IGTCountryDto GetIGTCountryByName(int siteId, string countryName)
        {
            return _dbContext.IGTCountryDtos.FromSqlRaw("pIGT_GetCountryBySiteID @CountryName, @UserID ",
                                                            new SqlParameter("@CountryName", countryName),
                                                                new SqlParameter("@UserID", siteId)).ToList().FirstOrDefault();
        }
    }
}
