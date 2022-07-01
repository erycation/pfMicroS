using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class PatronScratchCardDto
    {
        public string PatronNumber { get; set; }
        public string ScratchCard { get; set; }
        public int TileSelected { get; set; }
        public int WinningTileLocation { get; set; }
        public bool isWinner { get; set; }
        public string MessageReturned { get; set; }
        public DateTime DateInserted { get; set; }
        public string WinnerStatus
        {
            get
            {
                return isWinner == true ? "Yes" : "No";
            }
        }
    }
}
