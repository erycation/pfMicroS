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
    public class GamingAreaRepository : IGamingAreaRepository
    {

        private readonly PatronRewardsAdminDBContext _dbContext;

        public GamingAreaRepository(PatronRewardsAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<GamingAreaDto> GetGamingAreaBySiteId(int siteId)
        {

            return _dbContext.GamingAreaDtos.FromSqlRaw("pLBOARD_getGamingAreas @site",
                                                                    new SqlParameter("@site", siteId)).ToList();

        }

        public List<GamingAreaDto> GetGamingAreaByPromotionId(int siteId, int promotionId)
        {

            return _dbContext.GamingAreaDtos.FromSqlRaw("pLBOARD_getGamingAreasByPromo @site, @promotionId",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@promotionId", promotionId)).ToList();

        }

        public ReturnResult AddAreasForPromo(int siteId, int promotionId, string area)
        {

            return _dbContext.ReturnResults.FromSqlRaw("pLBOARD_InsAreasForPromo @site, @PromotionID,@Area ",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@PromotionID", promotionId),
                                                                    new SqlParameter("@Area", area)).ToList().FirstOrDefault();

        }

        public ReturnResult UnlinkAreasForPromo(int siteId, int promotionId)
        {

            return _dbContext.ReturnResults.FromSqlRaw("pLBOARD_UnLinkAreasForPromo @site, @PromotionID ",
                                                                    new SqlParameter("@site", siteId),
                                                                    new SqlParameter("@PromotionID", promotionId)).ToList().FirstOrDefault();

        }      
    }
}
