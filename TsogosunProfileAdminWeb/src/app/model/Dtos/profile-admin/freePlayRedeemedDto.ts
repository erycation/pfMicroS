
export interface FreePlayRedeemedDto {
    patron_ID: number;
    dateRecieved: Date;
    description?: string | undefined;
    amountReceived: number;
    loadedTo?: string | undefined;
    displayOn?: string | undefined;
    takeup?: string | undefined;
}