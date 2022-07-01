import { HasSiteId } from "../shared/hasSiteId";

export interface ScratchCardPrize extends HasSiteId{
    scratchCardPrizeID: number;
    scratchCardUID: string;
    numberOfPrizes: number;
    numberOfPrizesIssued: number;
    prizeTypeID: number;
    startRankID: number;
    endRankID: number;
    winningMsgID: number;
    nonWinningMsgID: number;
    sendTransactionalMessage: boolean;
    winingImagePath?: string | undefined;
    losingTileImagePath?: string | undefined;
}