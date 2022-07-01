using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using System.Security.Claims;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IActiveDirectoryAuthService _activeDirectoryAuthService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IActiveDirectoryAuthService activeDirectoryAuthService,
                                IHttpContextAccessor httpContextAccessor)
        {

            _activeDirectoryAuthService = activeDirectoryAuthService;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpPost]
        public IActionResult Login([FromBody] Credentials credentials)
        {
            var token = _activeDirectoryAuthService.Login(credentials);

            if(!token.Success)
                return BadRequest(new { message = token.Message });

            return Ok(token);
        }
    }    
}
