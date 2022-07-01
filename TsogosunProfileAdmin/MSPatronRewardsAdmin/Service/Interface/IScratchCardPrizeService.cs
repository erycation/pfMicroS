
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IScratchCardPrizeService
    {
        List<ScratchCardPrizeDto> GetScratchCardPrizeByScratchCardId(Guid scratchCardUID, int siteId);
        ReturnResult AddScratchCardPrize(ScratchCardPrizeDto scratchCardPrizeDto);
        ReturnResult UpdateScratchCardPrize(ScratchCardPrizeDto scratchCardPrizeDto);

    }
}
