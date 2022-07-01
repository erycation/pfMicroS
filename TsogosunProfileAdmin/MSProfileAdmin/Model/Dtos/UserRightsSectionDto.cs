

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class UserRightsSectionDto
    {
        public bool CanViewPersonalDetails { get; set; } = false;
        public bool CanUpdatePatron { get; set; } = false;
        public bool CanViewGamingPoints { get; set; } = false;
        public bool CanViewKPI { get; set; } = false;
        public bool CanViewOffers { get; set; } = false;
        public bool CanViewVIP { get; set; } = false;        
        public bool CanViewPatronDetailsScratchCard { get; set; } = false;
        public bool CanViewPatronLeaderBoard { get; set; } = false;
        public bool CanAddEditLeaderBoard { get; set; } = false;
        public bool CanViewPatronScratchCard { get; set; } = false;
        public bool CanViewScratchCardWinners { get; set; } = false;
        public bool CanAddEditScratchCard { get; set; } = false;
        public bool CanViewScratchCardOverview { get; set; } = false;
        public bool CanViewAuditLogs { get; set; } = false;
        
    }
}

