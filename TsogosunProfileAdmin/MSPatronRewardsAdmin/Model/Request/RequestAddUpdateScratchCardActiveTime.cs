

using MSPatronRewardsAdmin.Model.Dtos;

namespace MSPatronRewardsAdmin.Model.Request
{
    public class RequestAddUpdateScratchCardActiveTime
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ScratchCardActiveTimesDto ScratchCardActiveTimesDto { get; set; }
    }
}
