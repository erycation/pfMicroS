using MSPatronRewardsAdmin.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class LeaderBoardPromotionDto : HasSiteId
    {
        public int PromotionID { get; set; }
        public Guid PromotionUID { get; set; }
        public string PromotionName { get; set; }
        public string PromotionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short StartRank { get; set; }
        public short EndRank { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
        public DateTime DateInserted { get; set; } = DateTime.Now;
        public int NoPatrons { get; set; }
        public bool DisplayOnMobile { get; set; } 
        public bool Active { get; set; } = true;
        public string Status
        {
            get
            {
                return Active == true ? "Active" : "Not Active";
            }
        }
        public bool IsGroupLeaderBoard
        {
            get
            {
                return SiteId == 0 ? true : false;
            }
        }
        [NotMapped]
        public MobileSettingDto MobileSettingDto { get; set; }
        [NotMapped]
        public List<GamingAreaDto> GamingAreaDtos { get; set; }
       
        public string StartTimeSpam
        {
            
            get
            {
                return StartDate.ToString("HH:mm");
            }
        }       
        public string EndTimeSpam
        {
            get
            {
                return EndDate.ToString("HH:mm");
            }
        }
    }
}






