
using tsogosun.com.MSMDMPatron.Model.Dtos;

namespace tsogosun.com.MSMDMPatron.Repository.Interface
{
    public interface IGamingPointsRepository
    {
        GamingPointsTSGDto GetTSGGamingPointsByTsogosunId(long tsogosunID);
        GamingPointsUnitDto GetUnitGamingPointsByTsogosunId(long siteId, long patronNumber);
    }
}
