using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Shared;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSPatronRewardsAdmin.Repository
{
    public class LeaderBoardRepository : ILeaderBoardRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public LeaderBoardRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<LeaderBoardPromotionDto> GetLeaderBoardPromotionsBySiteId(int siteId, RequestLeaderBoard requestLeaderBoard)
        {

            return _dbContext.LeaderBoardPromotionDtos.FromSqlRaw("pLBOARD_getAllPromotions @site, @startdate, @endDate",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@startdate", requestLeaderBoard.StartDate),
                                                                    new SqlParameter("@endDate", requestLeaderBoard.EndDate)).ToList();

        }

        public InsertPromotionResponse AddLeaderBoardPromotion(LeaderBoardPromotionDto leaderBoardPromotion)
        {
            return _dbContext.InsertPromotionResponses.FromSqlRaw("pLBOARD_InsPromotion @site,@PromotionName,@PromotionType,@PromotionUID,@Startdate,@EndDate,@StartRank,@EndRank,@MinPoints,@MaxPoints,@DisplayOnMobile,@NoPatrons,@DateInserted,@Active ",
                                                                    new SqlParameter("@site", leaderBoardPromotion.SiteId),
                                                                    new SqlParameter("@PromotionName", leaderBoardPromotion.PromotionName),
                                                                    new SqlParameter("@PromotionType", leaderBoardPromotion.PromotionType),
                                                                    new SqlParameter("@PromotionUID", leaderBoardPromotion.PromotionUID),
                                                                    new SqlParameter("@Startdate", leaderBoardPromotion.StartDate),
                                                                    new SqlParameter("@EndDate", leaderBoardPromotion.EndDate),
                                                                    new SqlParameter("@StartRank", leaderBoardPromotion.StartRank),
                                                                    new SqlParameter("@EndRank", leaderBoardPromotion.EndRank),
                                                                    new SqlParameter("@MinPoints", leaderBoardPromotion.MinPoints),
                                                                    new SqlParameter("@MaxPoints", leaderBoardPromotion.MaxPoints),
                                                                    new SqlParameter("@DisplayOnMobile", leaderBoardPromotion.DisplayOnMobile),
                                                                    new SqlParameter("@NoPatrons", leaderBoardPromotion.NoPatrons),
                                                                    new SqlParameter("@DateInserted", leaderBoardPromotion.DateInserted),
                                                                    new SqlParameter("@Active", leaderBoardPromotion.Active)).ToList().FirstOrDefault();

        }

        public ReturnResult UpdateLeaderBoardPromotion(LeaderBoardPromotionDto leaderBoardPromotion)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pLBOARD_UpdPromotion @site,@PromotionID, @PromotionName,@PromotionType,@PromotionUID,@Startdate,@EndDate,@StartRank,@EndRank,@MinPoints,@MaxPoints,@DisplayOnMobile,@NoPatrons,@Active ",
                                                                    new SqlParameter("@site", leaderBoardPromotion.SiteId),
                                                                     new SqlParameter("@PromotionID", leaderBoardPromotion.PromotionID),
                                                                    new SqlParameter("@PromotionName", leaderBoardPromotion.PromotionName),
                                                                    new SqlParameter("@PromotionType", leaderBoardPromotion.PromotionType),
                                                                    new SqlParameter("@PromotionUID", leaderBoardPromotion.PromotionUID),
                                                                    new SqlParameter("@Startdate", leaderBoardPromotion.StartDate),
                                                                    new SqlParameter("@EndDate", leaderBoardPromotion.EndDate),
                                                                    new SqlParameter("@StartRank", leaderBoardPromotion.StartRank),
                                                                    new SqlParameter("@EndRank", leaderBoardPromotion.EndRank),
                                                                    new SqlParameter("@MinPoints", leaderBoardPromotion.MinPoints),
                                                                    new SqlParameter("@MaxPoints", leaderBoardPromotion.MaxPoints),
                                                                    new SqlParameter("@DisplayOnMobile", leaderBoardPromotion.DisplayOnMobile),
                                                                    new SqlParameter("@NoPatrons", leaderBoardPromotion.NoPatrons),
                                                                    new SqlParameter("@Active", leaderBoardPromotion.Active)).ToList().FirstOrDefault();

        }

        public LeaderBoardPromotionDto GetLeaderBoardByPromotionId(int siteId, int promotionId)
        {

            return _dbContext.LeaderBoardPromotionDtos.FromSqlRaw("pLBOARD_getPromotion @site, @promotionId",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@promotionId", promotionId)).ToList().SingleOrDefault();

        }

        public List<LeaderBoardPatronDto> GetLeaderBoardByPatronNumber(int siteId, long patronNo)
        {

            return _dbContext.LeaderBoardPatronDtos.FromSqlRaw("pRPT_LeaderBoard_PatronSearch @Site, @Patron",
                                                                    new SqlParameter("@Site", siteId),
                                                                    new SqlParameter("@Patron", patronNo)).ToList();

        }
    }
}