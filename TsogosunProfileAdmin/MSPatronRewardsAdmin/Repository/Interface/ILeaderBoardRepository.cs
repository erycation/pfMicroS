
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface ILeaderBoardRepository
    {
        List<LeaderBoardPromotionDto> GetLeaderBoardPromotionsBySiteId(int siteId, RequestLeaderBoard requestLeaderBoard);
        InsertPromotionResponse AddLeaderBoardPromotion(LeaderBoardPromotionDto leaderBoardPromotion);
        ReturnResult UpdateLeaderBoardPromotion(LeaderBoardPromotionDto leaderBoardPromotion);
        LeaderBoardPromotionDto GetLeaderBoardByPromotionId(int siteId, int promotionId);
        List<LeaderBoardPatronDto> GetLeaderBoardByPatronNumber(int siteId, long patronNo);
    }
}
