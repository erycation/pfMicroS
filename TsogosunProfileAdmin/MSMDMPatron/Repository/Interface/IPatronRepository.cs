
using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;

namespace tsogosun.com.MSMDMPatron.Repository.Interface
{
    public interface IPatronRepository
    {
        PatronStatusSummaryDetailsDto GetPatronSummaryTsogosunId(long tsogosunID);
        List<PatronSearchDto> GetPatrons(RequestPatronParameter requestPatronParameter);
        PatronDetailsDto GetPatronDetailsByTsogosunId(long tsogosunID);
        List<PatronSitesDto> GetPatronActiveSitesByTsogosunId(long tsogosunID);
        PatronDetailsSiteDto GetPatronDetailsBySiteAndTsogosunId(int siteId, long patronNumber, long tsogosunID);
        PatronRegisterdSitesDto GetPatronDetailsBySiteAndTsogosunId(string idNumber);
    }
}