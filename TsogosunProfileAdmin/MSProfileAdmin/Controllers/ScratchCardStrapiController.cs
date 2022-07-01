
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScratchCardStrapiController : ControllerBase
    {

        private readonly IScratchCardStrapiService _scratchCardStrapiService;

        public ScratchCardStrapiController(IScratchCardStrapiService scratchCardStrapiService)
        {
            _scratchCardStrapiService = scratchCardStrapiService;
        }

        [HttpGet("GetAll/{unitId}")]
        public async Task<List<ScratchCardStrapi>> GetScratchCardStrapiContentsByUnitId(int unitId)
        {
            return await _scratchCardStrapiService.GetScratchCardStrapiContentsByUnitId(unitId);
        }
    }
}
