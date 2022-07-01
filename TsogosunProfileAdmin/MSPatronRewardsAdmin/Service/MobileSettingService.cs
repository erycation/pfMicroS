using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Utils;

namespace MSPatronRewardsAdmin.Service
{
    public class MobileSettingService : IMobileSettingService
    {

        private readonly IMobileSettingRepository _mobileSettingRepository;

        public MobileSettingService(IMobileSettingRepository mobileSettingRepository)
        {
            _mobileSettingRepository = mobileSettingRepository;
        }

        public MobileSettingDto GetMobileSettingDtoByPromotionId(int siteId, int promotionId)
        {
            return _mobileSettingRepository.GetMobileSettingDtoByPromotionId(siteId, promotionId);
        }

        public ReturnResult AddOrUpdateMobileSettings(int siteId, MobileSettingDto mobileSettingDto)
        {
            return _mobileSettingRepository.AddOrUpdateMobileSettings(siteId, mobileSettingDto);
        }
    }
}
