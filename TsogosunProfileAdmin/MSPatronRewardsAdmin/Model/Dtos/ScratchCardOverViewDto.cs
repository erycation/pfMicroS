using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardOverViewDto
    {
        public string ScratchCard { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoPrizes { get; set; }
        public int NoPrizesRemainning { get; set; }
        public int? ScratchCardsAllocated { get; set; }
        public bool Active { get; set; }
        public string Status
        {
            get
            {
                return Active == true ? "Active" : "Not Active";
            }
        }
    }
}