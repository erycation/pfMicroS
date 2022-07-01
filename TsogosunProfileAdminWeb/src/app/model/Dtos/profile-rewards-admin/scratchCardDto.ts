import { HasSiteId } from "../../shared/hasSiteId";

export interface ScratchCardDto extends HasSiteId {
    scratchCardUID: string;
    description?: string | undefined;
    startDateTime: any;
    endDateTime: any;
    scratchCardImage?: string | undefined;
    scratchCardTitle?: string | undefined;
    scratchCardSubTitle?: string | undefined;
    tileImagePath?: string | undefined;
    numberOfPrizes: number;
    isActive: boolean;
    status?: string | undefined;
}

