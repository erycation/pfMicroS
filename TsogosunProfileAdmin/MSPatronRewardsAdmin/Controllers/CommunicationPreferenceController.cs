using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationPreferenceController : ControllerBase
    {
        private readonly ICommunicationPreferenceService _communicationPreferenceService;

        public CommunicationPreferenceController(ICommunicationPreferenceService communicationPreferenceService)
        {
            _communicationPreferenceService = communicationPreferenceService;
        }

        [HttpGet("All/{patronNo}/{siteId}")]
        public List<CommunicationPreferenceDto> GetAllCommunicationPreferencesBySiteId(string patronNo, int siteId)
        {
            return _communicationPreferenceService.GetAllCommunicationPreferencesBySiteId(patronNo, siteId);
        }
    }
}