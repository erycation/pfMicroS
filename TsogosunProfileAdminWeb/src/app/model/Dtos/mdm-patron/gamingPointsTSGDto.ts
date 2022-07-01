export interface GamingPointsTSGDto {
    tsogosunID?: number | undefined;
    slotPointsEarned: number;
    tablePointsEarned: number;
    totalPointsEarned: number;
    pointsToNextTier: number;
    slotPointsBalance: number;
    tablePointsBalance: number;
    totalPointsBalance?: number | undefined;
    footNote_Line1?: string | undefined;
    footNote_Line2?: string | undefined;
}