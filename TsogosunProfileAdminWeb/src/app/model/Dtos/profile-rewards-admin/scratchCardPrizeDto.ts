import { ScratchCardPrize } from "../../profile-rewards-admin/scratchCardPrize";

export interface ScratchCardPrizeDto extends ScratchCardPrize  {
    priceDescription?: string | undefined;
    winningMessage?: string | undefined;
    regretMessage?: string | undefined;    
    prizesAvailable: number;
    priceDetails?: string | undefined;

}