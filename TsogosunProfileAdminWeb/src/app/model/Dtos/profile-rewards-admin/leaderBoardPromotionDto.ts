import { HasSiteId } from "../../shared/hasSiteId";
import { GamingAreaDto } from "./gamingAreaDto";
import { MobileSettingDto } from "./mobileSettingDto";

export interface LeaderBoardPromotionDto extends HasSiteId {
    promotionID: number;
    promotionUID: string;
    promotionName?: string | undefined;
    promotionType?: string | undefined;
    startDate: any;
    endDate: any;
    startRank: number;
    endRank: number;
    minPoints: number;
    maxPoints: number;
    dateInserted: Date;
    noPatrons: number;
    displayOnMobile: boolean;
    active: boolean;
    status?: string | undefined;
    isGroupLeaderBoard: boolean;
    mobileSettingDto?: MobileSettingDto | undefined;
    gamingAreaDtos?: GamingAreaDto[] | undefined;
    startTimeSpam?: string | undefined;
    endTimeSpam?: string | undefined;
}