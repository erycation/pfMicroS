
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultPermissionGroupController : ControllerBase
    {

        private readonly IDefaultPermissionGroupService _defaultPermissionGroupService;

        public DefaultPermissionGroupController(IDefaultPermissionGroupService defaultPermissionGroupService)
        {
            _defaultPermissionGroupService = defaultPermissionGroupService;
        }

        [HttpGet("Active/{siteId}")]
        public List<DefaultPermissionGroup> GetActiveDefaultPermissionGroups(int siteId)
        {
            return _defaultPermissionGroupService.GetActiveDefaultPermissionGroups(siteId);
        }

        [HttpGet("All")]
        public List<DefaultPermissionGroup> GetAllDefaultPermissionGroups()
        {
            return _defaultPermissionGroupService.GetAllDefaultPermissionGroups();
        }
    }
}
