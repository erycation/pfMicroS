export interface ApprovedUserDetailsDto {
    siteId: number;
    userId: number;
    idpassportNO?: string | undefined;
    mobileNumber?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    rating?: number | undefined;
    recordStatus?: string | undefined;
    dateConfirmed?: Date | undefined;
    confirmedBy?: string | undefined;
}