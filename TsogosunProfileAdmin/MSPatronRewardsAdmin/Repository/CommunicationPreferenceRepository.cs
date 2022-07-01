
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Shared;
using System.Collections.Generic;
using System.Linq;

namespace MSPatronRewardsAdmin.Repository
{
    public class CommunicationPreferenceRepository : ICommunicationPreferenceRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public CommunicationPreferenceRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<CommunicationPreferenceDto> GetAllCommunicationPreferencesBySiteId(string patronNo, int siteId)
        {

            return _dbContext.CommunicationPreferenceDtos.FromSqlRaw("pSEL_PatronCommunication @PatronNumberOrID, @SiteID",
                                                             new SqlParameter("@PatronNumberOrID", patronNo),
                                                             new SqlParameter("@SiteID", siteId)).ToList();

        }
    }
}

