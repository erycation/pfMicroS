

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Shared;
using System.Collections.Generic;
using System.Linq;

namespace MSPatronRewardsAdmin.Repository
{
    public class PrizeTypeRepository : IPrizeTypeRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public PrizeTypeRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<PrizeTypeDto> GetPrizeTypesBySiteId(int siteId)
        {

            return _dbContext.PrizeTypeDtos.FromSqlRaw("pSCARD_getScratchCardPrizeTypes @site",
                                                                    new SqlParameter("@site", siteId)).ToList();

        }
    }
}
