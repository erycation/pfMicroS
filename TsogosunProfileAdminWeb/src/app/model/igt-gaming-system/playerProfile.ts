import { Address } from "./address";
import { CardNumber } from "./cardNumber";
import { Email } from "./email";
import { Employment } from "./employment";
import { Identification } from "./identification";
import { Interest } from "./interest";
import { Languages } from "./languages";
import { Name } from "./name";
import { PhoneNumber } from "./phoneNumber";
import { Restriction } from "./restriction";
import { SiteInfo } from "./siteInfo";
import { Status } from "./status";
import { userIGT } from "./userIGT";

export interface PlayerProfile {
    dateofBirth?: string | undefined;
    anniversary?: string | undefined;
    creditAccount?: string | undefined;
    gender?: string | undefined;
    pINLocked?: string | undefined;
    webEnabled?: string | undefined;
    nationality?: string | undefined;
    pipPep?: string | undefined;
    exempt?: string | undefined;
    attraction?: string | undefined;
    affiliation?: string | undefined;
    dateEnrolled?: string | undefined;
    name?: Name | undefined;
    enrolledBy?: userIGT | undefined;
    status?: Status | undefined;
    employment?: Employment | undefined;
    languages?: Languages[] | undefined;
    addresses?: Address[] | undefined;
    phoneNumbers?: PhoneNumber[] | undefined;
    identifications?: Identification[] | undefined;
    emails?: Email[] | undefined;
    cardNumbers?: CardNumber[] | undefined;
    playerRestrictions?: Restriction[] | undefined;
    interests?: Interest[] | undefined;
    siteParameters?: SiteInfo[] | undefined;
}