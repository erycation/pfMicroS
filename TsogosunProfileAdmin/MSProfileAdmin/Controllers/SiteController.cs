
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {

        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [HttpGet("Active")]
        public List<SiteDto> GetActiveSites()
        {
            return _siteService.GetActiveSites();
        }

        [HttpGet("All")]
        public List<SiteDto> GetAllSites()
        {
            return _siteService.GetAllSites();
        }
    }
}
