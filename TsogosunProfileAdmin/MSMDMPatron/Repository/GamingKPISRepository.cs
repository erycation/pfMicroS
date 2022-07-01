
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Shared;

namespace tsogosun.com.MSMDMPatron.Repository
{
    public class GamingKPISRepository : IGamingKPISRepository
    {

        private readonly MDMPatronDBContext _dbContext;

        public GamingKPISRepository(MDMPatronDBContext context)
        {
            _dbContext = context;
        }

        public List<GamingKPISDeffinitionDto> GetGamingKPISDeffinition()
        {
            return _dbContext.GamingKPISDeffinitionDtos.FromSqlRaw("TSGPA_pSEL_GamingKPIs_Deffinitions").ToList();
        }

        public GamingKPISUnitDto GetGamingKPISByPatronId(RequestGamingKPISUnit requestGamingKPISUnit)
        {
            return _dbContext.GamingKPISUnitDtos.FromSqlRaw("TSGPA_pSEL_Patron_GamingKPIs_ByPatronIDSite @PatronID, @SiteID, @StartDate, @EndDate",
                                                              new SqlParameter("@PatronID", requestGamingKPISUnit.PatronId),
                                                                new SqlParameter("@SiteID", requestGamingKPISUnit.SiteId),
                                                                  new SqlParameter("@StartDate", requestGamingKPISUnit.StartDate),
                                                                    new SqlParameter("@EndDate", requestGamingKPISUnit.EndDate)).ToList().FirstOrDefault();
        }

        public GamingKPISTSGDto GetGamingKPISByTsogosunId(RequestGamingKPISTSG requestGamingKPISTSG)
        {
            return _dbContext.GamingKPISTSGDtos.FromSqlRaw("TSGPA_pSEL_Patron_GamingKPIs_ByTsogosunID @TsogosunID, @StartDate, @EndDate",
                                                                       new SqlParameter("@TsogosunID", requestGamingKPISTSG.TsogosunId),
                                                                        new SqlParameter("@StartDate", requestGamingKPISTSG.StartDate),
                                                                         new SqlParameter("@EndDate", requestGamingKPISTSG.EndDate)).ToList().FirstOrDefault();
        }
    }
}
