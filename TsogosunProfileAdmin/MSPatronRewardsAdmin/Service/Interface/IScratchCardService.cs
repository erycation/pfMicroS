
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;


namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IScratchCardService
    {
        List<ScratchCardDto> GetScratchCardsBySiteId(int siteId);
        List<ScratchCardDto> GetActiveScratchCardsByDateRange(RequestScratchCard requestScratchCard, int siteId);
        List<PatronScratchCardDto> GetScratchCardsByPatronNumber(int siteId, long patronNumber);
        List<ScratchCardOverViewDto> GetScratchCardOverViewBySiteId(RequestOverview requestOverview, int siteId);
        //to be deleted
        List<ScratchCardWinnersDto> GetScratchWinnersByScratchId(Guid scratchCardUID, int siteId);
        //to be deleted
        byte[] GenerateWinnersReportByScratchId(Guid scratchCardUID, int siteId, string reportType);
        List<ScratchCardWinnersDto> GetScratchWinnersReport(RequestScratchCardHeader requestScratchCardHeader);
        byte[] GeneratScratchCardWinnersReport(RequestScratchCardHeader requestScratchCardHeader, string reportType);
        ScratchCardResponse AddScratchCard(ScratchCardDto scratchCard);
        ReturnResult UpdateScratchCard(ScratchCardDto scratchCard);
        ScratchCardDto GetScratchCardsByUId(Guid scratchCardUID, int siteId);
    }
}
