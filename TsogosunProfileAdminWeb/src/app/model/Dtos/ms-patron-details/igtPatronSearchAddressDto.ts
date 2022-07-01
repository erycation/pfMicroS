import { AddessConfirmedStatus } from "./addressConfirmedStatus";

export interface IGTPatronSearchAddressDto extends AddessConfirmedStatus  {
    siteId?: string | undefined;
    suburb?: string | undefined;
    city?: string | undefined;
    province?: string | undefined;
    country?: string | undefined;
    postalCode?: string | undefined;
}