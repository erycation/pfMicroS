export interface RequestGMAddress {
    siteId: number;
    provinceId: number;
    town?: string | undefined;
    suburb?: string | undefined;
    postalCode?: string | undefined;
}
