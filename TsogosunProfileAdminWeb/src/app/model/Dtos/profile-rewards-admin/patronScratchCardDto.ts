export interface PatronScratchCardDto {
    patronNumber?: string | undefined;
    scratchCard?: string | undefined;
    tileSelected: number;
    winningTileLocation: number;
    isWinner: boolean;
    messageReturned?: string | undefined;
    dateInserted: Date;
    winnerStatus?: string | undefined;
}