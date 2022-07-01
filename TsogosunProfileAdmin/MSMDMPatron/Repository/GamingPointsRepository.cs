

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Shared;

namespace tsogosun.com.MSMDMPatron.Repository
{
    public class GamingPointsRepository : IGamingPointsRepository
    {

        private readonly MDMPatronDBContext _dbContext;

        public GamingPointsRepository(MDMPatronDBContext context)
        {
            _dbContext = context;
        }

        public GamingPointsTSGDto GetTSGGamingPointsByTsogosunId(long tsogosunID)
        {

            return _dbContext.GamingPointsTSGDtos.FromSqlRaw("TSGPA_pSEL_Patron_GamingPoints_ByTsogosunID @TsogosunID",
                                                                       new SqlParameter("@TsogosunID", tsogosunID)).ToList().FirstOrDefault();

        }

        public GamingPointsUnitDto GetUnitGamingPointsByTsogosunId(long siteId, long patronNumber)
        {

            return _dbContext.GamingPointsUnitDtos.FromSqlRaw("TSGPA_pSEL_Patron_GamingPoints_BySiteID @PatronID, @SiteID ",
                                                                       new SqlParameter("@PatronID", patronNumber),
                                                                       new SqlParameter("@SiteID", siteId)).ToList().FirstOrDefault(); ;

        }
        
    }
}
