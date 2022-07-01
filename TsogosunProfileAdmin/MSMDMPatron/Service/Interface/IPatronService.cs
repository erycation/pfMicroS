
using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Shared.Paging;

namespace tsogosun.com.MSMDMPatron.Service.Interface
{
    public interface IPatronService
    {


        PatronStatusSummaryDetailsDto GetPatronSummaryTsogosunId(long tsogosunID);
        //to be replaced by paged GetPatrons
        List<PatronSearchDto> GetSearchedPatrons(RequestPatronParameter requestPatronParameter);
        PagedList<PatronSearchDto> GetPatrons(RequestPatronParameter requestPatronParameter);
        PatronDetailsDto GetPatronDetailsByTsogosunId(long tsogosunID);
        List<PatronSitesDto> GetPatronActiveSitesByTsogosunId(long tsogosunID);
        List<PatronSitesDto> GetPatronActiveSitesByUserSites(long tsogosunID, List<SiteDto> userSites);
        PatronDetailsSiteDto GetPatronDetailsBySiteAndTsogosunId(int siteId, long patronNumber, long tsogosunID);
        PatronRegisterdSitesDto GetPatronDetailsBySiteAndTsogosunId(string idNumber);
    }
}