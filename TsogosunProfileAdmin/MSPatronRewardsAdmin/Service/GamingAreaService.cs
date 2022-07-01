using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service
{
    public class GamingAreaService : IGamingAreaService
    {

        private readonly IGamingAreaRepository _gamingAreaRepository;

        public GamingAreaService(IGamingAreaRepository gamingAreaRepository)
        {
            _gamingAreaRepository = gamingAreaRepository;
        }

        public List<GamingAreaDto> GetAllGamingAreaBySiteId(int siteId)
        {
            return _gamingAreaRepository.GetGamingAreaBySiteId(siteId);
        }

        public List<GamingAreaDto> GetGamingAreaByPromotionId(int siteId, int promotionId)
        {
            return _gamingAreaRepository.GetGamingAreaByPromotionId(siteId, promotionId);
        }

        public ReturnResult AddAreasForPromo(int siteId, int promotionId, string area)
        {
            return _gamingAreaRepository.AddAreasForPromo(siteId, promotionId, area);
        }

        public ReturnResult UnlinkAreasForPromo(int siteId, int promotionId)
        {
            return _gamingAreaRepository.UnlinkAreasForPromo(siteId, promotionId);
        }
    }
}
