export interface PatronVoucherDto {
    iD: number;
    parentVoucherID: number;
    vendor?: string | undefined;
    voucherName?: string | undefined;
    voucherFullDescription?: string | undefined;
    pointsAmount: number;
    burnPoints?: string | undefined;
    amountAllowed: number;
    expiryDate: Date;
    displayOn?: string | undefined;
    offerStatus?: string | undefined;
    takeupMedium?: string | undefined;
    datePrinted?: Date | undefined;
    offerAvailability?: string | undefined;
    otpNumber?: number | undefined;
}
