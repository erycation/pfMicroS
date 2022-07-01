
using Microsoft.AspNetCore.Mvc;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScratchCardMessageController : ControllerBase
    {

        private readonly IScratchCardMessageService _scratchCardMessageService;

        public ScratchCardMessageController(IScratchCardMessageService scratchCardMessageService)
        {
            _scratchCardMessageService = scratchCardMessageService;
        }

        [HttpGet("Active/{siteId}")]
        public List<ScratchCardMessageDto> GetActiveScratchCardMessageBySiteId(int siteId)
        {
            return _scratchCardMessageService.GetActiveScratchCardMessageBySiteId(siteId);
        }

        [HttpGet("All/{siteId}")]
        public List<ScratchCardMessageDto> GetAllScratchCardMessageBySiteId(int siteId)
        {
            return _scratchCardMessageService.GetAllScratchCardMessageBySiteId(siteId);
        }
    }
}
