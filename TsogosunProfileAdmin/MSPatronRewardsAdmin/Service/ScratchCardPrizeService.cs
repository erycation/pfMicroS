
using MSPatronRewardsAdmin.Model;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Helpers;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Service
{
    public class ScratchCardPrizeService : IScratchCardPrizeService
    {

        private readonly IScratchCardPrizeRepository _scratchCardPrizeRepository;
        private readonly IScratchCardMessageService _scratchCardMessageService;

        public ScratchCardPrizeService(IScratchCardPrizeRepository scratchCardPrizeRepository,
                                        IScratchCardMessageService scratchCardMessageService)
        {
            _scratchCardPrizeRepository = scratchCardPrizeRepository;
            _scratchCardMessageService = scratchCardMessageService;
        }

        public List<ScratchCardPrizeDto> GetScratchCardPrizeByScratchCardId(Guid scratchCardUID, int siteId)
        {
            return _scratchCardPrizeRepository.GetScratchCardPrizeByScratchCardId(scratchCardUID, siteId);
        }

        public ReturnResult AddScratchCardPrize(ScratchCardPrizeDto scratchCardPrizeDto)
        {

            var requestScratchCardPrize = new ScratchCardPrizeDto
            {
                ScratchCardPrizeID = 0,
                ScratchCardUID = scratchCardPrizeDto.ScratchCardUID,
                NumberOfPrizes = scratchCardPrizeDto.NumberOfPrizes,
                NumberOfPrizesIssued = scratchCardPrizeDto.NumberOfPrizesIssued,
                PrizeTypeID = scratchCardPrizeDto.PrizeTypeID,
                StartRankID = scratchCardPrizeDto.StartRankID,
                EndRankID = scratchCardPrizeDto.EndRankID,
                WinningMsgID = 0,
                NonWinningMsgID = 0,
                WinningMessage = scratchCardPrizeDto.WinningMessage,
                RegretMessage = scratchCardPrizeDto.RegretMessage,
                SendTransactionalMessage = true,
                WiningImagePath = scratchCardPrizeDto.WiningImagePath,
                LosingTileImagePath = scratchCardPrizeDto.LosingTileImagePath
            };

            var responseScratchCardPrize = _scratchCardPrizeRepository.AddOrUpdateScratchCardPrize(scratchCardPrizeDto.SiteId, requestScratchCardPrize, 'A');

            if (responseScratchCardPrize.ReturnCode != 0)
                throw new AppException(responseScratchCardPrize.ReturnMessage);
            return responseScratchCardPrize;
        }

        public ReturnResult UpdateScratchCardPrize(ScratchCardPrizeDto scratchCardPrizeDto)
        {

            var requestScratchCardPrize = new ScratchCardPrizeDto
            {
                ScratchCardPrizeID = scratchCardPrizeDto.ScratchCardPrizeID,
                ScratchCardUID = scratchCardPrizeDto.ScratchCardUID,
                NumberOfPrizes = scratchCardPrizeDto.NumberOfPrizes,
                NumberOfPrizesIssued = scratchCardPrizeDto.NumberOfPrizesIssued,
                PrizeTypeID = scratchCardPrizeDto.PrizeTypeID,
                StartRankID = scratchCardPrizeDto.StartRankID,
                EndRankID = scratchCardPrizeDto.EndRankID,
                WinningMsgID = scratchCardPrizeDto.WinningMsgID,
                NonWinningMsgID = scratchCardPrizeDto.NonWinningMsgID,
                WinningMessage = scratchCardPrizeDto.WinningMessage,
                RegretMessage = scratchCardPrizeDto.RegretMessage,
                SendTransactionalMessage = true,
                WiningImagePath = scratchCardPrizeDto.WiningImagePath,
                LosingTileImagePath = scratchCardPrizeDto.LosingTileImagePath
            };

            var responseScratchCardPrize = _scratchCardPrizeRepository.AddOrUpdateScratchCardPrize(scratchCardPrizeDto.SiteId, requestScratchCardPrize, 'U');
            if (responseScratchCardPrize.ReturnCode != 0)
                throw new AppException(responseScratchCardPrize.ReturnMessage);

            var updateWinningMessage = new ScratchCardMessageDto
            {
                MessageId = scratchCardPrizeDto.WinningMsgID,
                MessageToDisplay = scratchCardPrizeDto.WinningMessage,
                IsActive = true
            };

            var responseWinningMsg = _scratchCardMessageService.UpdateScratchCardMessage(updateWinningMessage, scratchCardPrizeDto.SiteId);
            if (responseWinningMsg.ReturnCode == 1)
                throw new AppException(responseWinningMsg.ReturnMessage);

            var updateRegretMessage = new ScratchCardMessageDto
            {
                MessageId = scratchCardPrizeDto.NonWinningMsgID,
                MessageToDisplay = scratchCardPrizeDto.RegretMessage,
                IsActive = true
            };

            var responseRegretMesg = _scratchCardMessageService.UpdateScratchCardMessage(updateRegretMessage, scratchCardPrizeDto.SiteId);
            if (responseRegretMesg.ReturnCode == 1)
                throw new AppException(responseRegretMesg.ReturnMessage);

            return responseScratchCardPrize;

        }
    }
}
