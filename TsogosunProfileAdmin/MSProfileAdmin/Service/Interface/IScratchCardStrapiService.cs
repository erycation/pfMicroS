
using System.Collections.Generic;
using System.Threading.Tasks;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IScratchCardStrapiService
    {
         Task<List<ScratchCardStrapi>> GetScratchCardStrapiContentsByUnitId(int unitId);
    }
}
