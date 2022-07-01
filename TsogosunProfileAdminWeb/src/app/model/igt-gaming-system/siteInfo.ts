import { Ranking } from "./ranking";
import { userIGT } from "./userIGT";

export interface SiteInfo {
    siteID?: string | undefined;
    pointBalance?: string | undefined;
    ranking?: Ranking | undefined;
    host?: userIGT | undefined;
}