
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IScratchCardRepository
    {
        List<ScratchCardDto> GetScratchCardsBySiteId(int siteId);
        ScratchCardDto GetScratchCardsByUId(Guid scratchCardUID, int siteId);
        List<PatronScratchCardDto> GetScratchCardsByPatronNumber(int siteId, long PatronNumber);
        List<ScratchCardOverViewDto> GetScratchCardOverViewBySiteId(int siteId);
        ScratchCardHeaderDto GetScratchCardHeader(RequestScratchCardHeader requestScratchCardHeader);
        List<ScratchCardWinnersDto> GetScratchWinnersReport(RequestScratchCardHeader requestScratchCardHeader);
        List<ScratchCardWinnersDto> GetScratchWinnersByScratchId(Guid scratchCardUID, int siteId);        
        ReturnResult AddOrUpdateScratchCard(ScratchCardDto scratchCard, char action);

    }
}
