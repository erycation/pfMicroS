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
    public class MobileSettingRepository : IMobileSettingRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public MobileSettingRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public MobileSettingDto GetMobileSettingDtoByPromotionId(int siteId, int promotionId)
        {


            return _dbContext.MobileSettingDtos.FromSqlRaw("pLBOARD_getMobileSettingsByPromo @site, @promotionId",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@promotionId", promotionId)).ToList().SingleOrDefault();

        }

        public ReturnResult AddOrUpdateMobileSettings(int siteId, MobileSettingDto mobileSettingDto)
        {
            return _dbContext.ReturnResults.FromSqlRaw("pLBOARD_InsMobileSettings @site, @PromotionID,@MainImage, @MainHeading ",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@PromotionID", mobileSettingDto.PromotionID),
                                                                    new SqlParameter("@MainImage", mobileSettingDto.MainImage),
                                                                    new SqlParameter("@MainHeading", mobileSettingDto.MainHeading)).ToList().FirstOrDefault();
        }
    }
}