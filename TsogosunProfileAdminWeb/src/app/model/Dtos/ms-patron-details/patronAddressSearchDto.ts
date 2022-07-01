export interface PatronAddressSearchDto {
    pcId: number;
    countryID?: number | undefined;
    country?: string | undefined;
    provID?: number | undefined;
    provDescription?: string | undefined;
    town?: string | undefined;
    area?: string | undefined;
    postalCode?: string | undefined;
}