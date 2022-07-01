
using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class LeaderBoardPatronDto
    {
        public long PromotionID { get; set; }
        public long PatronNumber { get; set; }
        public string PromotionName { get; set; }
        public string PromotionType { get; set; }
        public int Position { get; set; }
        public long Points { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
