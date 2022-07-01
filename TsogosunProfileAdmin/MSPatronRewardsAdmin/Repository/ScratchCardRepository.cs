using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Shared;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSPatronRewardsAdmin.Repository
{
    public class ScratchCardRepository : IScratchCardRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public ScratchCardRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<ScratchCardDto> GetScratchCardsBySiteId(int siteId)
        {

            return _dbContext.ScratchCardDtos.FromSqlRaw("pSCARD_getAllScratchCard @site",
                                                                    new SqlParameter("@site", siteId)).ToList();

        }

        public ScratchCardDto GetScratchCardsByUId(Guid scratchCardUID, int siteId)
        {

            return _dbContext.ScratchCardDtos.FromSqlRaw("pSCARD_getScratchCardByUID @site, @ScratchCardUID",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@ScratchCardUID", scratchCardUID)).ToList().FirstOrDefault(); 

        }

        

        public List<PatronScratchCardDto> GetScratchCardsByPatronNumber(int siteId, long patronNumber)
        {

            return _dbContext.PatronScratchCardDtos.FromSqlRaw("pSCARD_getScratchCardByPatronNumber @site, @PatronNumber",
                                                                    new SqlParameter("@site", siteId),
                                                                     new SqlParameter("@patronNumber", patronNumber)).ToList();

        }

        public List<ScratchCardOverViewDto> GetScratchCardOverViewBySiteId(int siteId)
        {

            return _dbContext.ScratchCardOverViewDtos.FromSqlRaw("pRPT_ScratchCard_OverView @site",
                                                                   new SqlParameter("@site", siteId)).ToList();

        }

        public ScratchCardHeaderDto GetScratchCardHeader(RequestScratchCardHeader requestScratchCardHeader)
        {

            return _dbContext.ScratchCardHeaderDtos.FromSqlRaw("pRPT_ScratchCard_Headers @Site, @Promo, @PrizeType, @Message",
                                                                        new SqlParameter("@Site", requestScratchCardHeader.Site),
                                                                        new SqlParameter("@Promo", requestScratchCardHeader.PromotionUID),
                                                                        new SqlParameter("@PrizeType", requestScratchCardHeader.PrizeType),
                                                                        new SqlParameter("@Message", requestScratchCardHeader.Message)).ToList().SingleOrDefault();


        }

        public List<ScratchCardWinnersDto> GetScratchWinnersReport(RequestScratchCardHeader requestScratchCardHeader)
        {

            return _dbContext.ScratchCardWinnersDtos.FromSqlRaw("pRPT_ScratchCard_Winners @Site, @Promo, @PrizeType, @Message",
                                                                       new SqlParameter("@Site", requestScratchCardHeader.Site),
                                                                       new SqlParameter("@Promo", requestScratchCardHeader.PromotionUID),
                                                                       new SqlParameter("@PrizeType", requestScratchCardHeader.PrizeType),
                                                                       new SqlParameter("@Message", requestScratchCardHeader.Message)).ToList();

        }
    
        
        public List<ScratchCardWinnersDto> GetScratchWinnersByScratchId(Guid scratchCardUID, int siteId)
        {

            return _dbContext.ScratchCardWinnersDtos.FromSqlRaw("pRPT_ScratchCard_Winners @site, @Promo",
                                                                  new SqlParameter("@site", siteId),
                                                                  new SqlParameter("@Promo", scratchCardUID)).ToList();

        }

        

        public ReturnResult AddOrUpdateScratchCard(ScratchCardDto scratchCard, char action)
        {

            return _dbContext.ReturnResults.FromSqlRaw("pSCARD_InsScratchCard @site, @ScratchCardUID,@ScratchCardName,@StartDate,@EndDate,@ScratchCardImage,@TileImagePath,@ScratchCardTilesID,@IsActive,@Action ",
                                                                    new SqlParameter("@site", scratchCard.SiteId),
                                                                    new SqlParameter("@ScratchCardUID", scratchCard.ScratchCardUID),
                                                                    new SqlParameter("@ScratchCardName", scratchCard.Description),
                                                                    new SqlParameter("@StartDate", scratchCard.StartDateTime),
                                                                    new SqlParameter("@EndDate", scratchCard.EndDateTime),
                                                                    new SqlParameter("@ScratchCardImage", scratchCard.ScratchCardImage),
                                                                    new SqlParameter("@TileImagePath", scratchCard.TileImagePath),
                                                                    new SqlParameter("@ScratchCardTilesID", 1),
                                                                    new SqlParameter("@IsActive", scratchCard.isActive),
                                                                    new SqlParameter("@Action", action)
                                                                    ).ToList().FirstOrDefault();

        }
    }
}


