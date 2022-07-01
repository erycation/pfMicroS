

export interface PatronStatusSummaryDetailsDto {
    tsogoSunID?: number | undefined;
    enrolmentDate?: Date | undefined;
    title?: string | undefined;
    initials?: string | undefined;
    firstName?: string | undefined;
    middleName?: string | undefined;
    lastName?: string | undefined;
    hostedBy?: string | undefined;
    customerRank: number;
    customerTier?: string | undefined;
    iDNumber?: string | undefined;
    profileStatus?: string | undefined;
    identityNumber?: string | undefined;
    groupStatus?: string | undefined;  
}