
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Shared;
using MSPatronRewardsAdmin.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSPatronRewardsAdmin.Repository
{
    public class ScratchCardPrizeRepository : IScratchCardPrizeRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public ScratchCardPrizeRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<ScratchCardPrizeDto> GetScratchCardPrizeByScratchCardId(Guid scratchCardUID, int siteId)
        {

            return _dbContext.ScratchCardPrizeDtos.FromSqlRaw("pSCARD_getScratchPrizeByScratchCard @site, @scratchCardUID",
                                                                    new SqlParameter("@site", siteId),
                                                                     new SqlParameter("@scratchCardUID", scratchCardUID)).ToList();

        }

        public ReturnResult AddOrUpdateScratchCardPrize(int siteId, ScratchCardPrizeDto scratchCardPrize, char action)
        {
       

            return _dbContext.ReturnResults.FromSqlRaw("pSCARD_InsScratchCardPrize @site,@ScratchCardPrizeID, @ScratchCardUID,@NumberOfPrizes, " +
                                                                                    "@NumberOfPrizesIssued,@PrizeTypeID," +
                                                                                    "@StartRankID,@EndRankID, @WinningMsgID, " +
                                                                                    "@NonWinningMsgID,@WiningMessage,@LosingMessage, @SendTransactionalMessage," +
                                                                                    "@WiningImagePath ,@LosingTileImagePath, @Action",
                                                                    new SqlParameter("@site", siteId),                                                                    
                                                                    new SqlParameter("@ScratchCardPrizeID", scratchCardPrize.ScratchCardPrizeID),
                                                                    new SqlParameter("@ScratchCardUID", scratchCardPrize.ScratchCardUID),
                                                                    new SqlParameter("@NumberOfPrizes", scratchCardPrize.NumberOfPrizes),
                                                                    new SqlParameter("@NumberOfPrizesIssued", scratchCardPrize.NumberOfPrizesIssued),
                                                                    new SqlParameter("@PrizeTypeID", scratchCardPrize.PrizeTypeID),
                                                                    new SqlParameter("@StartRankID", scratchCardPrize.StartRankID),
                                                                    new SqlParameter("@EndRankID", scratchCardPrize.EndRankID),
                                                                    new SqlParameter("@WinningMsgID", scratchCardPrize.WinningMsgID),
                                                                    new SqlParameter("@NonWinningMsgID", scratchCardPrize.NonWinningMsgID),
                                                                    new SqlParameter("@WiningMessage", scratchCardPrize.WinningMessage),
                                                                    new SqlParameter("@LosingMessage", scratchCardPrize.RegretMessage),
                                                                    new SqlParameter("@SendTransactionalMessage", scratchCardPrize.SendTransactionalMessage),
                                                                    new SqlParameter("@WiningImagePath", scratchCardPrize.WiningImagePath),
                                                                    new SqlParameter("@LosingTileImagePath", scratchCardPrize.LosingTileImagePath),
                                                                    new SqlParameter("@Action", action)).ToList().FirstOrDefault(); 

        }
    }
}
