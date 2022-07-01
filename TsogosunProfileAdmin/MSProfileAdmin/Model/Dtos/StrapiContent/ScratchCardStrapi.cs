using System;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent.ScratchCardImages;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent
{
    public class ScratchCardStrapi
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Order { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        //public Image1 Image1 { get; set; }
        //public Image2 Image2 { get; set; }
        //public Image3 Image3 { get; set; }
        //public Image4 Image4 { get; set; }
        //public Image5 Image5 { get; set; }
        public TileImage TileImage { get; set; }        
        public LosingImage LosingImage { get; set; }        
        public WinningImage WinningImage { get; set; }
        public BackgroundImage BackgroundImage { get; set; }        

    }
}
