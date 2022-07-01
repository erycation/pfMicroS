using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardHeaderDto
    {
        public string SiteName { get; set; }
        public string PromoName { get; set; }
        public string PrizeType { get; set; }
        public string Message { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
