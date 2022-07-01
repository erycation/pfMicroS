using System;

namespace MSPatronRewardsAdmin.Model.Request
{
    public class RequestScratchCardHeader
    {
        public int Site { get; set; }
        public Guid PromotionUID { get; set; }
        public int PrizeType { get; set; }
        public string Message { get; set; }
    }
}
