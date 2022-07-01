
using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Model.Request;
using MSPatronRewardsAdmin.Model.Response;
using MSPatronRewardsAdmin.Shared.Utils;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface ILeaderBoardService
    {
        InsertPromotionResponse AddLeaderBoard(RequestAddUpdateLeaderBoard requestAddUpdateLeaderBoard);
        ReturnResult UpdateLeaderBoard(RequestAddUpdateLeaderBoard requestAddUpdateLeaderBoard);        
        List<LeaderBoardPromotionDto> GetLeaderBoardPromotionsBySiteId(int siteId, RequestLeaderBoard requestLeaderBoard);
        LeaderBoardPromotionDto GetLeaderBoardByPromotionId(int siteId, int promotionId);        
        List<LeaderBoardPatronDto> GetLeaderBoardByPatronNumber(int siteId, long patronNo);
    }
}
