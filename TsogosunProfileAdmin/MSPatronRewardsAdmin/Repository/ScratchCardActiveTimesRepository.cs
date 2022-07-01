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
    public class ScratchCardActiveTimesRepository : IScratchCardActiveTimesRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public ScratchCardActiveTimesRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }


        public List<ScratchCardActiveTimesDto> GetScratchCardActiveTimesBySiteId(int siteId, Guid scratchCardUID)
        {

            return _dbContext.ScratchCardActiveTimesDtos.FromSqlRaw("pSCARD_getScratchCardActiveTimes @site, @scratchCardUID",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@scratchCardUID", scratchCardUID)).ToList();

        }

        public ReturnResult AddOrUpdateScratchCardActiveTimes(int siteId, ScratchCardActiveTimesDto scratchCardActiveTimesDto, char action)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pSCARD_InsScratchCardActiveTimes @site, @ScratchCardReleaseID,@ScratchCardUID,@StartDateTime,@EndDateTime,@IsActive,@Action ",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@ScratchCardReleaseID", scratchCardActiveTimesDto.ScratchCardReleaseID),
                                                                    new SqlParameter("@ScratchCardUID", scratchCardActiveTimesDto.ScratchCardUID),
                                                                    new SqlParameter("@StartDateTime", scratchCardActiveTimesDto.StartDateTime),
                                                                    new SqlParameter("@EndDateTime", scratchCardActiveTimesDto.EndDateTime),
                                                                    new SqlParameter("@IsActive", scratchCardActiveTimesDto.isActive),
                                                                    new SqlParameter("@Action", action)
                                                                    ).ToList().FirstOrDefault();
        }
    }
}
