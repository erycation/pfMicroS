import { ConfirmedPatronDetails } from "./confirmed-patron/confirmedPatronDetails";

export interface GMSConfirmedPatronDetailsDto extends ConfirmedPatronDetails {
    countryID: number;
    provID: number;
    pcId: number;
    documentTypeId: number;
    documentExpireDate?: Date | undefined;  
    pippep: number;
}