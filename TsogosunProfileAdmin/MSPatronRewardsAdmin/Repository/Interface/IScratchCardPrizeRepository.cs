
using MSPatronRewardsAdmin.Model;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IScratchCardPrizeRepository
    {
        List<ScratchCardPrizeDto> GetScratchCardPrizeByScratchCardId(Guid scratchCardUID, int siteId);
        ReturnResult AddOrUpdateScratchCardPrize(int siteId, ScratchCardPrizeDto scratchCardPrize, char action);
    }
}
