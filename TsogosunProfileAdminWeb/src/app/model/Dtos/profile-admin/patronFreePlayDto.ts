export interface PatronFreePlayDto {
    iD: number;
    vendor?: string | undefined;
    xtraCreditFullDescription?: string | undefined;
    startDate: Date;
    endDate: Date;
    cost: number;
    expiryDate?: Date | undefined;
    redemptionType?: string | undefined;
    mobileImageURL?: string | undefined;
    offerStatus?: string | undefined;
    takeupMedium?: string | undefined;
    dateReceived?: Date | undefined;
    loadedTo?: string | undefined;
    offerAvailability?: string | undefined;
    otpNumber?: number | undefined;
}