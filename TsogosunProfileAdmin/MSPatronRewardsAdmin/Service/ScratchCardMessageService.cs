
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Helpers;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;
using System.Linq;


namespace MSPatronRewardsAdmin.Service
{
    public class ScratchCardMessageService : IScratchCardMessageService
    {

        private readonly IScratchCardMessageRepository _scratchCardMessageRepository;

        public ScratchCardMessageService(IScratchCardMessageRepository scratchCardMessageRepository)
        {
            _scratchCardMessageRepository = scratchCardMessageRepository;
        }

        public List<ScratchCardMessageDto> GetActiveScratchCardMessageBySiteId(int siteId)
        {
            return _scratchCardMessageRepository.GetScratchCardMessageBySiteId(siteId).Where(sm => sm.IsActive == true).ToList();
        }

        public List<ScratchCardMessageDto> GetAllScratchCardMessageBySiteId(int siteId)
        {
            return _scratchCardMessageRepository.GetScratchCardMessageBySiteId(siteId);
        }

        public ReturnResult AddScratchCardMessage(ScratchCardMessageDto scratchCardMessageDto, int siteId)
        {
            var requestScratchCardMessageDto = new ScratchCardMessageDto
            {
                MessageId = 0,
                MessageToDisplay = scratchCardMessageDto.MessageToDisplay,
                IsActive = true
            };

            var responseScratchCardMessageDto = _scratchCardMessageRepository.AddScratchCardMessage(siteId, requestScratchCardMessageDto, 'A');
            if (responseScratchCardMessageDto.ReturnCode != 0)
                throw new AppException(responseScratchCardMessageDto.ReturnMessage);
            return responseScratchCardMessageDto;
        }

        public ReturnResult UpdateScratchCardMessage(ScratchCardMessageDto scratchCardMessageDto, int siteId)
        {
            var requestScratchCardMessageDto = new ScratchCardMessageDto
            {
                MessageId = scratchCardMessageDto.MessageId,
                MessageToDisplay = scratchCardMessageDto.MessageToDisplay,
                IsActive = scratchCardMessageDto.IsActive
            };

            var responseScratchCardMessageDto = _scratchCardMessageRepository.AddScratchCardMessage(siteId, requestScratchCardMessageDto, 'U');
            if (responseScratchCardMessageDto.ReturnCode != 0)
                throw new AppException(responseScratchCardMessageDto.ReturnMessage);
            return responseScratchCardMessageDto;

        }
    }
}
