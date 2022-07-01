

using tsogosun.com.MSMDMPatron.Model.Dtos;

namespace tsogosun.com.MSMDMPatron.Service.Interface
{
    public interface IGamingPointsService
    {
        GamingPointsTSGDto GetTSGGamingPointsByTsogosunId(long tsogosunID);
        GamingPointsUnitDto GetUnitGamingPointsByTsogosunId(long siteId, long patronNumber);
    }
}
