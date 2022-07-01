export interface GMSPatronDetails {
    idpassportNumber?: string | undefined;
    countryOfIssue?: string | undefined;
    docExpiryDate?: Date | undefined;  
    nationality?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    birthday: Date;
    gender?: string | undefined;
    address1?: string | undefined;
    address2?: string | undefined;
    pcID?: string | undefined;
    provID: number;
    countryID: number;
    pipPEP: number;
    documentType: number;
    allowCommConsent: boolean;
    allowCommSMS: boolean;
    allowCommEmail: boolean;
    allowCommPhone: boolean;
    allowCommPost: boolean;
    mobileNo?: string | undefined;
    landLineNo?: string | undefined;
    email?: string | undefined;
    photo?: string | undefined;
}