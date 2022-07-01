using MSPatronRewardsAdmin.Shared;
using System;


namespace MSPatronRewardsAdmin.Model
{
    public class ScratchCardPrize : HasSiteId
    {
        public long ScratchCardPrizeID { get; set; }
        public Guid ScratchCardUID { get; set; }
        public int NumberOfPrizes { get; set; }
        public int NumberOfPrizesIssued { get; set; }
        public short PrizeTypeID { get; set; }
        public short StartRankID { get; set; }
        public short EndRankID { get; set; }
        public int WinningMsgID { get; set; }
        public int NonWinningMsgID { get; set; }
        public bool SendTransactionalMessage { get; set; }
        public string WiningImagePath { get; set; }
        public string LosingTileImagePath { get; set; }
    }
}
