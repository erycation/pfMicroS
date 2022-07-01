
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface ISiteService
    {
        List<SiteDto> GetAllSites();
        List<SiteDto> GetActiveSites();
    }
}
