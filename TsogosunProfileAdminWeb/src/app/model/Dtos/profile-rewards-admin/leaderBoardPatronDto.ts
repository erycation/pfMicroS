export interface LeaderBoardPatronDto {
    promotionID: number;
    patronNumber: number;
    promotionName?: string | undefined;
    promotionType?: string | undefined;
    position: number;
    points: number;
    lastUpdate: Date;
}