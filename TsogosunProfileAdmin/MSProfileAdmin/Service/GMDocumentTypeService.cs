using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class GMDocumentTypeService : IGMDocumentTypeService
    {

        private readonly IGMDocumentTypeRepository _gmdocumentTypeRepository;

        public GMDocumentTypeService(IGMDocumentTypeRepository gmdocumentTypeRepository)
        {
            _gmdocumentTypeRepository = gmdocumentTypeRepository;
        }

        public List<GMDocumentTypeDto> GetDocumentTypesBySiteId(int siteId)
        {
            return _gmdocumentTypeRepository.GetDocumentTypesBySiteId(siteId);
        }       
    }
}
