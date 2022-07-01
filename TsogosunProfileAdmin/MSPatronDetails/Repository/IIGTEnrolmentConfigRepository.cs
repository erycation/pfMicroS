
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Shared;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTConfig;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTPatronDetails;

namespace tsogosun.com.MSPatronDetails.Repository
{
    public class IGTEnrolmentConfigRepository : IIGTEnrolmentConfigRepository
    {

        private readonly PatronDetailsDBContext _dbContext;

        public IGTEnrolmentConfigRepository(PatronDetailsDBContext context)
        {
            _dbContext = context;
        }

        public List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions()
        {
            return _dbContext.IGTEnrolmentConfigDtos.FromSqlRaw("pSel_IGTEnrolmentConfigurations").ToList();
        }

        public IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId)
        {
            return _dbContext.IGTEnrolmentConfigDtos.FromSqlRaw("pSel_IGTEnrolmentConfigBySiteID @SiteID ",
                                                           new SqlParameter("@SiteID", siteId)).ToList().FirstOrDefault();
        }
    }
}
