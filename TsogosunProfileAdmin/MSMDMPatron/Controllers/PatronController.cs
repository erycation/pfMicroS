using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Service.Interface;
using tsogosun.com.MSMDMPatron.Shared.Paging;

namespace tsogosun.com.MSMDMPatron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronController : ControllerBase
    {
        private readonly IPatronService _patronService;

        public PatronController(IPatronService patronService)
        {
            _patronService = patronService;
        }

        [HttpGet("Get/Summary/{tsogosunID}")]
        public PatronStatusSummaryDetailsDto GetPatronSummaryTsogosunId(long tsogosunID)
        {
            return _patronService.GetPatronSummaryTsogosunId(tsogosunID);
        }

        //to be replaced by paged GetPatrons
        [HttpGet("GetAll")]
        public List<PatronSearchDto> GetSearchedPatrons([FromQuery] RequestPatronParameter requestPatronParameter)
        {
            return _patronService.GetSearchedPatrons(requestPatronParameter);
        }

        [HttpGet]
        public PagedList<PatronSearchDto> GetPatrons([FromQuery] RequestPatronParameter requestPatronParameter)
        {
            return _patronService.GetPatrons(requestPatronParameter);
        }

        [HttpGet("Get/{tsogosunID}")]
        public PatronDetailsDto GetPatronDetailsByTsogosunId(long tsogosunID)
        {
            return _patronService.GetPatronDetailsByTsogosunId(tsogosunID);
        }

        [HttpGet("Get/Sites/{tsogosunID}")]
        public List<PatronSitesDto> GetPatronActiveSitesByTsogosunId(long tsogosunID)
        {
            return _patronService.GetPatronActiveSitesByTsogosunId(tsogosunID);
        }

        [HttpPost("ActiveSites/{tsogosunID}")]
        public List<PatronSitesDto> GetPatronActiveSitesByUserSites(long tsogosunID, [FromBody] List<SiteDto> userSites)
        {
            return _patronService.GetPatronActiveSitesByUserSites(tsogosunID, userSites);
        }

        [HttpGet("Sites/PatronNumber/{siteId}/{patronNumber}/{tsogosunID}")]
        public PatronDetailsSiteDto GetPatronSitesByTsogosunId(int siteId, long patronNumber, long tsogosunID)
        {
            return _patronService.GetPatronDetailsBySiteAndTsogosunId(siteId, patronNumber, tsogosunID);
        }

        [HttpGet("RegisteredSite/{idNumber}")]
        public PatronRegisterdSitesDto GetPatronDetailsBySiteAndTsogosunId(string idNumber)
        {
            return _patronService.GetPatronDetailsBySiteAndTsogosunId(idNumber);
        }        
    }
}
