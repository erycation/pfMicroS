
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IScratchCardMessageRepository
    {
        List<ScratchCardMessageDto> GetScratchCardMessageBySiteId(int siteId);
        ReturnResult AddScratchCardMessage(int siteId, ScratchCardMessageDto scratchCardMessageDto, char action);

    }
}
