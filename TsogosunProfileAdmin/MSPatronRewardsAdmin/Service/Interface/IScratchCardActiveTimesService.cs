using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IScratchCardActiveTimesService
    {
        List<ScratchCardActiveTimesDto> GetScratchCardActiveTimesBySiteId(int siteId, Guid scratchCardUID);
        ReturnResult AddScratchCardActiveTimes(RequestAddUpdateScratchCardActiveTime requestAddUpdateScratchCardActiveTime, int siteId);
        ReturnResult UpdateScratchCardActiveTimes(RequestAddUpdateScratchCardActiveTime requestAddUpdateScratchCardActiveTime, int siteId);
    }
}
