import { ConfirmedPatronDetails } from "./confirmed-patron/confirmedPatronDetails";

export interface IGTConfirmedPatronDetailsDto extends ConfirmedPatronDetails {
    pcId?: number | undefined;   
}
