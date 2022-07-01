
export interface VoucherAvailableDto {
    returnCode: number;
    refNo?: string | undefined;
    voucherID: number;
    vendorName?: string | undefined;
    voucherName?: string | undefined;
    displaySection?: string | undefined;
    expiryDate?: Date | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
}