
export interface FreePlayAvailableDto {
    iD: number;
    vendor?: string | undefined;
    xtraCreditDescription?: string | undefined;
    xtraCreditFullDescription?: string | undefined;
    startDate: Date;
    endDate: Date;
    cost: number;
    amountAllowed: number;
    expiryDate: Date;
    redemptionType?: string | undefined;
    mobileImageURL?: string | undefined;
}