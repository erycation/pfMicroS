import { RequestGamingKPIS } from "./requestGamingKPIS";

export interface RequestGamingKPISUnit extends RequestGamingKPIS {
    patronId: number;
    siteId: number;
}