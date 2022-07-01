
export interface VoucherRedeemedDto {
    description?: string | undefined;
    patronNumber?: string | undefined;
    vendorName?: string | undefined;
    datePrinted?: Date | undefined;
    cost: number;
    displayOn?: string | undefined;
    takeup?: string | undefined;
}