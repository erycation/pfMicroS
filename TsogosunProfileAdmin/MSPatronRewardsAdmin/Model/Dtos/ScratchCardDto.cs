using MSPatronRewardsAdmin.Shared;
using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardDto : HasSiteId
    {
        public Guid ScratchCardUID { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScratchCardImage { get; set; }
        public string ScratchCardTitle { get; set; }
        public string ScratchCardSubTitle { get; set; }
        public string TileImagePath { get; set; }
        public int ScratchCardTilesID { get; set; } = 1;
        public int NumberOfPrizes { get; set; } 
        public bool isActive { get; set; } = true;
        public string Status
        {
            get
            {
                return isActive == true ? "Active" : "Not Active";
            }
        }
    }
}