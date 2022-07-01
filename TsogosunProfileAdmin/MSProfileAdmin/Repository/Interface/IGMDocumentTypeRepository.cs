
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IGMDocumentTypeRepository
    {
        List<GMDocumentTypeDto> GetDocumentTypesBySiteId(int siteId);
    }
}
