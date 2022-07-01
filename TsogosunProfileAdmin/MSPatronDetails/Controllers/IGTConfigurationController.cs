
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTConfig;
using tsogosun.com.MSPatronDetails.Service.Interface;

namespace tsogosun.com.MSPatronDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IGTConfigurationController : ControllerBase
    {

        private readonly IIGTEnrolmentConfigService _iIGTEnrolmentConfigService;

        public IGTConfigurationController(IIGTEnrolmentConfigService iGTEnrolmentConfigService)
        {
            _iIGTEnrolmentConfigService = iGTEnrolmentConfigService;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions()
        {
            return _iIGTEnrolmentConfigService.GetAllEnrollmentConfigutaions();
        }

        [HttpGet]
        [Route("Get/{siteId}")]
        public IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId)
        {
            return _iIGTEnrolmentConfigService.GetEnrollmentConfigutaionBySiteId(siteId);
        }
    }
}
