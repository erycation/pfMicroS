import { PatronDetailsInfo } from "../patron-Info-Details/patronDetailsInfo";

export interface ConfirmedPatronDetails extends PatronDetailsInfo {
    id: number;
    webSiteID?: number | undefined;
    mobileRegID?: string | undefined;
    title?: string | undefined;
    gender?: string | undefined;
    birthDate: Date;
    occupation?: string | undefined;
    emailAddress?: string | undefined;
    nationalityID: number;
    nationality?: string | undefined;
    notes?: string | undefined;
    iLikePromotions?: boolean | undefined;
    isOnHold?: boolean | undefined;
    isConfirmed?: boolean | undefined;
    confirmedBy?: string | undefined;
    dateConfirmed?: Date | undefined;
    address1?: string | undefined;
    address2?: string | undefined;
    town?: string | undefined;
    area?: string | undefined;
    postalCode?: string | undefined;
    country?: string | undefined;
    provDescription?: string | undefined;
    idpassImage?: string | undefined;
    idPassCountry?: string | undefined;
    siteID?: number | undefined;
    preferredSms?: boolean | undefined;
    preferredEmail?: boolean | undefined;
    preferredPhoneCall?: boolean | undefined;
    isSigningUpForRewards?: boolean | undefined;    
    preferredPost?: boolean | undefined;
    originatedFrom?: string | undefined;
    formatIdPassImage?: string | undefined;
    
}
