

using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service
{
    public class PrizeTypeService : IPrizeTypeService
    {

        private readonly IPrizeTypeRepository _prizeTypeRepository;

        public PrizeTypeService(IPrizeTypeRepository prizeTypeRepository)
        {
            _prizeTypeRepository = prizeTypeRepository;
        }

        public List<PrizeTypeDto> GetPrizeTypesBySiteId(int siteId)
        {
            return _prizeTypeRepository.GetPrizeTypesBySiteId(siteId);
        }
    }
}
