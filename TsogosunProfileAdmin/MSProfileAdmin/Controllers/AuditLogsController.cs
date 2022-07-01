using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {

        private readonly IAuditLogsService _logFilesService;

        public AuditLogsController(IAuditLogsService logFilesService)
        {
            _logFilesService = logFilesService;
        }

        [HttpGet("GetAll")]
        public List<LogFilesDto> GetLogFiles()
        {

            return _logFilesService.GetLogFiles();

        }

        [HttpPost("Clear")]
        public IActionResult ClearLogs()
        {
            _logFilesService.DeleteLogFiles();
            return Ok();
        }

    }
}
