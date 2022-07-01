
export interface DrawRedeemedDto {
    patron_ID: number;
    description?: string | undefined;
    drawDate: Date;
    tickets?: number | undefined;
    displayOn?: string | undefined;
    takeup?: string | undefined;
}