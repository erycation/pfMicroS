import { PatronDetailsInfoDto } from "./patronDetailsInfoDto";

export interface UnconfirmedGMSPatronDetailsInfoDto extends PatronDetailsInfoDto {
    pcId?: number | undefined;
    documentTypeId?: number | undefined;
    documentExpireDate?: Date | undefined;
    pippep?: number | undefined;
}