

using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IMobileSettingService
    {
        MobileSettingDto GetMobileSettingDtoByPromotionId(int siteId, int promotionId);
        ReturnResult AddOrUpdateMobileSettings(int siteId, MobileSettingDto mobileSettingDto);

    }
}
