using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GMDocumentTypeController : ControllerBase
    {
        private readonly IGMDocumentTypeService _gmdocumentTypeService;

        public GMDocumentTypeController(IGMDocumentTypeService gmdocumentTypeService)
        {
            _gmdocumentTypeService = gmdocumentTypeService;
        }

        [HttpGet("Get/{siteId}")]
        public List<GMDocumentTypeDto> GetDocumentTypesBySiteId(int siteId)
        {
            return _gmdocumentTypeService.GetDocumentTypesBySiteId(siteId);
        }      
    }
}
