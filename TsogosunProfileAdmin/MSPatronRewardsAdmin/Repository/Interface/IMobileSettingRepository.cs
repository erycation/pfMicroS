

using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IMobileSettingRepository
    {

        MobileSettingDto GetMobileSettingDtoByPromotionId(int siteId, int promotionId);
        ReturnResult AddOrUpdateMobileSettings(int siteId, MobileSettingDto mobileSettingDto);

    }
}
