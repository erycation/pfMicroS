
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Shared;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;
using System.Linq;

namespace MSPatronRewardsAdmin.Repository
{
    public class ScratchCardMessageRepository : IScratchCardMessageRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public ScratchCardMessageRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<ScratchCardMessageDto> GetScratchCardMessageBySiteId(int siteId)
        {

            return _dbContext.ScratchCardMessageDtos.FromSqlRaw("pSCARD_getScratchCardMessage @site",
                                                                    new SqlParameter("@site", siteId)).ToList();

        }

        public ReturnResult AddScratchCardMessage(int siteId, ScratchCardMessageDto scratchCardMessageDto, char action)
        {

            return _dbContext.ReturnResults.FromSqlRaw("pSCARD_InsScratchCardMessage @site,@MessageID,@MessageToDisplay,@IsActive, @Action ",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@MessageID", scratchCardMessageDto.MessageId),
                                                                    new SqlParameter("@MessageToDisplay", scratchCardMessageDto.MessageToDisplay),
                                                                    new SqlParameter("@IsActive", scratchCardMessageDto.IsActive),
                                                                    new SqlParameter("@Action", action)).ToList().FirstOrDefault(); ;

        }
        
    }
}
