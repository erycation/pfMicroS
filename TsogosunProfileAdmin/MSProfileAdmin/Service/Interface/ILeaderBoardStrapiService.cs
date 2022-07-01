
using System.Collections.Generic;
using System.Threading.Tasks;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface ILeaderBoardStrapiService
    {
        Task<List<LeaderBoardStrapi>> GetLeaderBoardStrapiContentsByUnitId(int unitId);
    }
}
