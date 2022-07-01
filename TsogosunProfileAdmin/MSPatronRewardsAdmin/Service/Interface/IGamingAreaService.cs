using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IGamingAreaService
    {
        List<GamingAreaDto> GetAllGamingAreaBySiteId(int siteId);
        List<GamingAreaDto> GetGamingAreaByPromotionId(int siteId, int promotionId);
        ReturnResult AddAreasForPromo(int siteId, int promotionId, string area);
        ReturnResult UnlinkAreasForPromo(int siteId, int promotionId);
    }
}
