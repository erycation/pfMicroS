using System;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent.LeaderBoardImages;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent
{
    public class LeaderBoardStrapi
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Order { get; set; }
        public string Tier { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public Image Image { get; set; }
    }
}
