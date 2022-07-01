
using System;
using System.Collections.Generic;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class AuthToken : UserRightsSectionDto
    {
        public int UserId { get; set; }
        public Guid UserSessionId { get; set; }
        public string Username { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public List<ApplicationDto> Applications { get; set; }
        public List<NavItem> NavItems { get; set; }
        public List<StatusDto> StatusItems { get; set; }
        public List<PrizeType> PrizeTypes { get; set; }
        public List<RankDto> Ranks { get; set; }
        public List<PointsTypeDto> PointsTypes { get; set; }
        public List<GenderDto> Genders { get; set; }

    }
}
