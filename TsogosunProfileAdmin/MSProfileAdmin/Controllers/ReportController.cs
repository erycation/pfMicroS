
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("PatronFreePlay")]
        public List<PatronFreePlayDto> GetPatronFreePlays([FromQuery] RequestPatronFreePlay requestPatronFreePlay)
        {
            return _reportService.GetPatronFreePlays(requestPatronFreePlay);
        }

        [HttpGet("PatronVoucher")]
        public List<PatronVoucherDto> GetPatronVouchers([FromQuery] RequestPatronVoucher requestPatronVoucher)
        {
            return _reportService.GetPatronVouchers(requestPatronVoucher);
        }

        [HttpGet("PatronDraw")]
        public List<PatronDrawDto> GetPatronDraws([FromQuery] RequestPatronDraw requestPatronDraw)
        {
            return _reportService.GetPatronDraws(requestPatronDraw);
        }
    }
}
