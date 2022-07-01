

using MSPatronRewardsAdmin.Model.Dtos;

namespace MSPatronRewardsAdmin.Model.Request
{
    public class RequestAddUpdateLeaderBoard 
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public LeaderBoardPromotionDto LeaderBoardPromotionDto { get; set; }

    }
}
