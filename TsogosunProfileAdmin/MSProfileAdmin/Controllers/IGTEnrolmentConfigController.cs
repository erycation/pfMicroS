
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTPatronDetails;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IGTEnrolmentConfigController : ControllerBase
    {

        private readonly IIGTEnrolmentConfigService _iIGTEnrolmentConfigService;

        public IGTEnrolmentConfigController(IIGTEnrolmentConfigService iGTEnrolmentConfigService)
        {
            _iIGTEnrolmentConfigService = iGTEnrolmentConfigService;
        }

        [HttpGet("GetAll")]
        public List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions()
        {
            return _iIGTEnrolmentConfigService.GetAllEnrollmentConfigutaions();
        }

        [HttpGet("Get/{siteId}")]
        public IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId)
        {
            return _iIGTEnrolmentConfigService.GetEnrollmentConfigutaionBySiteId(siteId);
        }

        [HttpGet("Country/{siteId}/{countryName}")]
        public IGTCountryDto GetIGTCountryByName(int siteId, string countryName)
        {
            return _iIGTEnrolmentConfigService.GetIGTCountryByName(siteId, countryName);
        }
    }
}
