using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IGamingAreaRepository
    {
        List<GamingAreaDto> GetGamingAreaBySiteId(int siteId);
        List<GamingAreaDto> GetGamingAreaByPromotionId(int siteId, int promotionId);
        ReturnResult AddAreasForPromo(int siteId, int promotionId, string area);
        ReturnResult UnlinkAreasForPromo(int siteId, int promotionId);
    }
}
