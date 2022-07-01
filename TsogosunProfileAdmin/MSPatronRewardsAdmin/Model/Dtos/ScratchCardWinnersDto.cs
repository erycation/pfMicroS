using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardWinnersDto
    {

        //@SiteNameTMP AS SiteName, @PromoTMP AS Promotion,@PrizeTypeTMP AS PromotionType,@Message, Getdate() AS ExecutionDate

        public string SiteName { get; set; }
        public string Promotion { get; set; }
        public string PromotionType { get; set; }
        public string Message { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string Winner { get; set; }
        public string MobileUserID { get; set; }
        public string PatronNumber { get; set; }
        //public int? isWinner { get; set; }
        public int TileSelected { get; set; }
        public int WinningTileLocation { get; set; }
        public string PrizeType { get; set; }
        public string MessageReturned { get; set; }
        public DateTime DateInserted { get; set; }
        //public string WinnerStatus
        //{
        //    get
        //    {
        //        return isWinner == 1 ? "Yes" : "No";
        //    }
        //}
    }
}
