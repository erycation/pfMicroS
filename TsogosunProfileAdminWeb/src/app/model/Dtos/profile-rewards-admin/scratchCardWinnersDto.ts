export interface ScratchCardWinnersDto {
    mobileUserID?: string | undefined;
    patronNumber?: string | undefined;
    winner?: string | undefined;
    tileSelected: number;
    winningTileLocation: number;
    prizeType?: string | undefined;
    messageReturned?: string | undefined;
    dateInserted: Date;
    winnerStatus?: string | undefined;
}
