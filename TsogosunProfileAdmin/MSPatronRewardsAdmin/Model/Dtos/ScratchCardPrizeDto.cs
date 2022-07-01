
namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardPrizeDto : ScratchCardPrize
    {
        public string PriceDescription { get; set; }
        public string WinningMessage { get; set; }
        public string RegretMessage { get; set; }
        public int PrizesAvailable { get; set; }
        public string PriceDetails
        {
            get
            {
                return $"{PriceDescription}({NumberOfPrizes}) - {WinningMessage}";
            }
        }

    }
}
