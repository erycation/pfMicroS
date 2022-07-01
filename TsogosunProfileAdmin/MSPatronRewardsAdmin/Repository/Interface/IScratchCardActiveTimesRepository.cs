
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IScratchCardActiveTimesRepository
    {
        List<ScratchCardActiveTimesDto> GetScratchCardActiveTimesBySiteId(int siteId, Guid scratchCardUID);
        ReturnResult AddOrUpdateScratchCardActiveTimes(int siteId, ScratchCardActiveTimesDto scratchCardActiveTimesDto, char action);

    }
}
