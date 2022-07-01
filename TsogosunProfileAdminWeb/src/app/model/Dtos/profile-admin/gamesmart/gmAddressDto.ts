export interface GMAddressDto {
    siteId: number;
    postalCodeId: number;
    country?: string | undefined;
    province?: string | undefined;
    town?: string | undefined;
    suburb?: string | undefined;
    postalCode?: string | undefined;
    provinceId?: number | undefined;
}