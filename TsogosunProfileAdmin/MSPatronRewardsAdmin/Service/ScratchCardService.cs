using AspNetCore.Reporting;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared.Helpers;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSPatronRewardsAdmin.Service
{
    public class ScratchCardService : IScratchCardService
    {

        private readonly IScratchCardRepository _scratchCardRepository;

        public ScratchCardService(IScratchCardRepository scratchCardRepository)
        {
            _scratchCardRepository = scratchCardRepository;
        }

        public List<ScratchCardDto> GetScratchCardsBySiteId(int siteId)
        {
            return _scratchCardRepository.GetScratchCardsBySiteId(siteId);
        }

        public List<ScratchCardDto> GetActiveScratchCardsByDateRange(RequestScratchCard requestScratchCard, int siteId)
        {

            var startOfDay = DateUtil.StartOfDay(requestScratchCard.StartDate);
            var endOfDay = DateUtil.EndOfDay(requestScratchCard.EndDate);
            return _scratchCardRepository.GetScratchCardsBySiteId(siteId).Where(s => s.StartDateTime >= startOfDay && s.EndDateTime <= endOfDay).ToList();

        }

        public ScratchCardDto GetScratchCardsByUId(Guid scratchCardUID, int siteId)
        {
            return _scratchCardRepository.GetScratchCardsByUId(scratchCardUID, siteId);
        }

        public List<PatronScratchCardDto> GetScratchCardsByPatronNumber(int siteId, long patronNumber)
        {
            return _scratchCardRepository.GetScratchCardsByPatronNumber(siteId, patronNumber);
        }

        public List<ScratchCardOverViewDto> GetScratchCardOverViewBySiteId(RequestOverview requestOverview, int siteId)
        {
            var startOfDay = DateUtil.StartOfDay(requestOverview.StartDate);
            var endOfDay = DateUtil.EndOfDay(requestOverview.EndDate);
            return _scratchCardRepository.GetScratchCardOverViewBySiteId(siteId).Where(o => o.StartDate >= startOfDay && o.StartDate <= endOfDay).ToList();
        }


        //to be deleted
        public List<ScratchCardWinnersDto> GetScratchWinnersByScratchId(Guid scratchCardUID, int siteId)
        {
            return _scratchCardRepository.GetScratchWinnersByScratchId(scratchCardUID,siteId);
        }

        public byte[] GenerateWinnersReportByScratchId(Guid scratchCardUID, int siteId, string reportType)
        {

            string rdlcFilePath = string.Format("ReportFiles\\ScratchCardWinners.rdl");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(rdlcFilePath);

            parameters.Add("Site", siteId.ToString());
            parameters.Add("StartDate", DateTime.Now.ToString());
            parameters.Add("EndDate", DateTime.Now.ToString());
            parameters.Add("Promo", scratchCardUID.ToString());

            var scratchCardWinnersDtos = GetScratchWinnersByScratchId(scratchCardUID, siteId);

            report.AddDataSource("Main", scratchCardWinnersDtos);
            var result = report.Execute(GetRenderType(reportType), 1, parameters);
            return result.MainStream;

        }

        public ScratchCardHeaderDto GetScratchCardHeader(RequestScratchCardHeader requestScratchCardHeader)
        {
            return _scratchCardRepository.GetScratchCardHeader(requestScratchCardHeader);
        }

        public List<ScratchCardWinnersDto> GetScratchWinnersReport(RequestScratchCardHeader requestScratchCardHeader)
        {
            return _scratchCardRepository.GetScratchWinnersReport(requestScratchCardHeader); 
        }

        public byte[] GeneratScratchCardWinnersReport(RequestScratchCardHeader requestScratchCardHeader, string reportType)
        {
            string rdlcFilePath = string.Format("ReportFiles\\ScratchCardWinners.rdl");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(rdlcFilePath);

            parameters.Add("Site", requestScratchCardHeader.Site.ToString());
            parameters.Add("StartDate", DateTime.Now.ToString());
            parameters.Add("EndDate", DateTime.Now.ToString());
            parameters.Add("Promo", requestScratchCardHeader.PromotionUID.ToString());
            parameters.Add("PrizeType", requestScratchCardHeader.PrizeType.ToString());
            parameters.Add("Message", requestScratchCardHeader.Message.ToString());

            var scratchCardReport = GetScratchWinnersReport(requestScratchCardHeader);

            report.AddDataSource("Main", scratchCardReport);            
            var result = report.Execute(GetRenderType(reportType), 1, parameters);
            return result.MainStream;

        }

        public ScratchCardResponse AddScratchCard(ScratchCardDto scratchCard)
        {          
            var requestScractCard = new ScratchCardDto
            {
                ScratchCardUID = Guid.NewGuid(),
                Description = scratchCard.Description,
                StartDateTime = scratchCard.StartDateTime,
                EndDateTime = scratchCard.EndDateTime,
                ScratchCardImage = scratchCard.ScratchCardImage,
                TileImagePath = scratchCard.TileImagePath,
                SiteId = scratchCard.SiteId
            };

            var responseScratchCard = _scratchCardRepository.AddOrUpdateScratchCard(requestScractCard, 'A');
            if (responseScratchCard.ReturnCode == 0)
                throw new AppException(responseScratchCard.ReturnMessage);
            return new ScratchCardResponse { ScratchCardUID = requestScractCard.ScratchCardUID, ReturnMessage = responseScratchCard.ReturnMessage };
        }

        public ReturnResult UpdateScratchCard(ScratchCardDto scratchCard)
        {

            var requestScractCard = new ScratchCardDto
            {
                ScratchCardUID = scratchCard.ScratchCardUID,
                Description = scratchCard.Description,
                StartDateTime = scratchCard.StartDateTime,
                EndDateTime = scratchCard.EndDateTime,
                isActive = scratchCard.isActive,
                ScratchCardTilesID = scratchCard.ScratchCardTilesID,
                ScratchCardSubTitle = scratchCard.ScratchCardSubTitle,
                ScratchCardImage = scratchCard.ScratchCardImage,
                TileImagePath = scratchCard.TileImagePath,
                SiteId = scratchCard.SiteId

            };

            var responseScratchCard = _scratchCardRepository.AddOrUpdateScratchCard(requestScractCard, 'U');
            if (responseScratchCard.ReturnCode == 0)
                throw new AppException(responseScratchCard.ReturnMessage);
            return responseScratchCard;

        }

        #region private_methods

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = RenderType.Pdf;
                    break;
                case "word":
                    renderType = RenderType.Word;
                    break;
                case "excel":
                    renderType = RenderType.Excel;
                    break;
            }

            return renderType;
        }

        #endregion
    }
}
