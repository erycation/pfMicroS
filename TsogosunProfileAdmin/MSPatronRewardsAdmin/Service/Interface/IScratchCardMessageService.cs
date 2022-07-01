
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IScratchCardMessageService
    {
        List<ScratchCardMessageDto> GetActiveScratchCardMessageBySiteId(int siteId);
        List<ScratchCardMessageDto> GetAllScratchCardMessageBySiteId(int siteId);
        ReturnResult AddScratchCardMessage(ScratchCardMessageDto scratchCardMessageDto, int siteId);
        ReturnResult UpdateScratchCardMessage(ScratchCardMessageDto scratchCardMessageDto, int siteId);

    }
}
