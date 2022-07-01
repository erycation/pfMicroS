using Microsoft.AspNetCore.Mvc;
using System;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        public AuditController() { }

        [HttpGet("Otp/{otpNumber}")]
        public Boolean AuditUserViewOTPNumber()
        {
            return true;
        }
    }
}
