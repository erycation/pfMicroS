using System;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Service.Interface;
using tsogosun.com.MSMDMPatron.Shared.Paging;

namespace tsogosun.com.MSMDMPatron.Service
{
    public class PatronService : IPatronService
    {

        private readonly IPatronRepository _patronRepository;

        public PatronService(IPatronRepository patronRepository)
        {
            _patronRepository = patronRepository;
        }

        public PatronStatusSummaryDetailsDto GetPatronSummaryTsogosunId(long tsogosunID)
        {
            return _patronRepository.GetPatronSummaryTsogosunId(tsogosunID);
        }

        //to be replaced by paged GetPatrons
        public List<PatronSearchDto> GetSearchedPatrons(RequestPatronParameter requestPatronParameter)
        {
            return _patronRepository.GetPatrons(requestPatronParameter);
        }

        public PagedList<PatronSearchDto> GetPatrons(RequestPatronParameter requestPatronParameter)
        {
            var result = _patronRepository.GetPatrons(requestPatronParameter);

            return PagedList<PatronSearchDto>.ToPagedList(result.AsQueryable(),
                requestPatronParameter.CurrentPage,
                requestPatronParameter.PageSize);

        }

        public PatronDetailsDto GetPatronDetailsByTsogosunId(long tsogosunID)
        {
            return _patronRepository.GetPatronDetailsByTsogosunId(tsogosunID);
        }

        public List<PatronSitesDto> GetPatronActiveSitesByTsogosunId(long tsogosunID)
        {

            return _patronRepository.GetPatronActiveSitesByTsogosunId(tsogosunID);

        }

        public List<PatronSitesDto> GetPatronActiveSitesByUserSites(long tsogosunID, List<SiteDto> userSites)
        {

            var sitesAbbr = new List<string>();
            foreach (var site in userSites)
            {
                sitesAbbr.Add(site.SiteName);
            }

            return _patronRepository.GetPatronActiveSitesByTsogosunId(tsogosunID).Where(s => sitesAbbr.Contains(s.SiteShortName)).ToList(); ;

        }

        public PatronDetailsSiteDto GetPatronDetailsBySiteAndTsogosunId(int siteId, long patronNumber, long tsogosunID)
        {
            return _patronRepository.GetPatronDetailsBySiteAndTsogosunId(siteId, patronNumber, tsogosunID);
        }

        public PatronRegisterdSitesDto GetPatronDetailsBySiteAndTsogosunId(string idNumber)
        {
            return _patronRepository.GetPatronDetailsBySiteAndTsogosunId(idNumber);
        }
    }
}

