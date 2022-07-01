
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _userPermissionService;

        public UserPermissionController(IUserPermissionService userPermissionService)
        {
            _userPermissionService = userPermissionService;
        }

        [HttpPost("Add")]
        public IActionResult AddUserPermission([FromBody] UserPermission userPermission)
        {
            var responseUserPermision = _userPermissionService.AddUserPermission(userPermission);

            if (!responseUserPermision.Success)
                return BadRequest(new { message = "Something went wrong" });
            return Ok(responseUserPermision.Success);
        }

        [HttpPost("Deactivate")]
        public IActionResult DeactivateUserPermission([FromBody] UserPermission userPermission)
        {
            var responseUserPermision = _userPermissionService.DeactivateUserPermission(userPermission);

            if (!responseUserPermision.Success)
                return BadRequest(new { message = "Something went wrong" });
            return Ok(responseUserPermision.Success);
        }
    }
}
