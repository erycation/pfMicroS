using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Shared;

namespace tsogosun.com.MSMDMPatron.Repository
{
    public class PatronRepository : IPatronRepository
    {

        private readonly MDMPatronDBContext _dbContext;

        public PatronRepository(MDMPatronDBContext context)
        {
            _dbContext = context;
        }

        public PatronStatusSummaryDetailsDto GetPatronSummaryTsogosunId(long tsogosunID)
        {

            return _dbContext.PatronStatusSummaryDetailsDtos.FromSqlRaw("TSGPA_pSEL_Patron_StatusSummaryDetails_ByTsogosunID @TsogosunID",
                                                                           new SqlParameter("@TsogosunID", tsogosunID)).ToList().FirstOrDefault();

        }

        public List<PatronSearchDto> GetPatrons(RequestPatronParameter requestPatronParameter)
        {

            return _dbContext.PatronSearchDtos.FromSqlRaw("TSGPA_pSEL_Patron_Search @SiteID, @PatronNumber, @IDPassport, @MobileNumber, @PatronName, @PatronSurname, @EmailAddress",
                                                                        new SqlParameter("@SiteID", requestPatronParameter.SiteID),
                                                                        new SqlParameter("@PatronNumber", requestPatronParameter.PatronNumber),
                                                                        new SqlParameter("@IDPassport", string.IsNullOrEmpty(requestPatronParameter.IDPassport) ? DBNull.Value : requestPatronParameter.IDPassport),
                                                                        new SqlParameter("@MobileNumber", string.IsNullOrEmpty(requestPatronParameter.MobileNumber) ? DBNull.Value : requestPatronParameter.MobileNumber),
                                                                        new SqlParameter("@PatronName", string.IsNullOrEmpty(requestPatronParameter.PatronName) ? DBNull.Value : requestPatronParameter.PatronName),
                                                                        new SqlParameter("@PatronSurname", string.IsNullOrEmpty(requestPatronParameter.PatronSurname) ? DBNull.Value : requestPatronParameter.PatronSurname),
                                                                        new SqlParameter("@EmailAddress", string.IsNullOrEmpty(requestPatronParameter.EmailAddress) ? DBNull.Value : requestPatronParameter.EmailAddress)).ToList();


        }

        public PatronDetailsDto GetPatronDetailsByTsogosunId(long tsogosunID)
        {
            return _dbContext.PatronDetailsDtos.FromSqlRaw("TSGPA_pSEL_Patron_ProfileDetails_ByTsogosunID @TsogosunID",
                                                                           new SqlParameter("@TsogosunID", tsogosunID)).ToList().FirstOrDefault();


        }

        public List<PatronSitesDto> GetPatronActiveSitesByTsogosunId(long tsogosunID)
        {
            return _dbContext.PatronSitesDtos.FromSqlRaw("TSGPA_pSEL_Patron_ActiveSites_ByTsogosunID @TsogosunID",
                                                                        new SqlParameter("@TsogosunID", tsogosunID)).ToList();

        }

        public PatronDetailsSiteDto GetPatronDetailsBySiteAndTsogosunId(int siteId, long patronNumber, long tsogosunID)
        {
            return _dbContext.PatronDetailsSiteDtos.FromSqlRaw("TSGPA_pSEL_Patron_ProfileDetails_ByPatronIDSite @TsogosunID, @PatronNumber, @SiteID",
                                                                          new SqlParameter("@TsogosunID", tsogosunID),
                                                                          new SqlParameter("@PatronNumber", patronNumber),
                                                                           new SqlParameter("@SiteID", siteId)).ToList().FirstOrDefault();


        }
        public PatronRegisterdSitesDto GetPatronDetailsBySiteAndTsogosunId(string idNumber)
        {
            return _dbContext.PatronRegisterdSitesDtos.FromSqlRaw("TSGPA_pSEL_PatronRegisteredOtherSite @IDNumber",
                                                                          new SqlParameter("@IDNumber", idNumber)).ToList().FirstOrDefault();


        }        
    }
}

