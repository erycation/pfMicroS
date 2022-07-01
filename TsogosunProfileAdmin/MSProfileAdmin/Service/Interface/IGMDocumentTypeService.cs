
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IGMDocumentTypeService
    {
        List<GMDocumentTypeDto> GetDocumentTypesBySiteId(int siteId);
    }
}
