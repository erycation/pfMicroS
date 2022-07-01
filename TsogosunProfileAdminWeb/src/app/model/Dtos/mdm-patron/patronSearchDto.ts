export interface PatronSearchDto {
    tsogosunid?: number | undefined;
    patronID: number;
    property_Registered?: number | undefined;
    siteName?: string | undefined;
    firstName?: string | undefined;
    middleName?: string | undefined;
    lastName?: string | undefined;
    fullName?: string | undefined;
    fIC_IDNumber?: string | undefined;
    cellNumber?: string | undefined;
    customerRank: number;
    customerTier?: string | undefined;
    profileStatus?: string | undefined;
    lastPlayDate?: Date | undefined;
    identityNumber?: string | undefined;
    
}