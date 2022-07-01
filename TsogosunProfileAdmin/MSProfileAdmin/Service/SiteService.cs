

using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class SiteService : ISiteService
    {

        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public List<SiteDto> GetActiveSites()
        {
            var sites = _siteRepository.GetAllSites().Where(s => s.isActive == true).ToList();
            var sitesDto = new List<SiteDto>();

            foreach(var site in sites)
            {
                sitesDto.Add(new SiteDto(site));
            }

            return sitesDto;
        }

        public List<SiteDto> GetAllSites()
        {
            var sites = _siteRepository.GetAllSites();
            var sitesDto = new List<SiteDto>();

            foreach (var site in sites)
            {
                sitesDto.Add(new SiteDto(site));
            }
            return sitesDto;
        }
    }
}
