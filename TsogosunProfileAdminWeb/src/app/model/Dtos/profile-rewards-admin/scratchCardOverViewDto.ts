export interface ScratchCardOverViewDto {
    scratchCard?: string | undefined;
    startDate: Date;
    endDate: Date;
    noPrizes: number;
    noPrizesRemainning: number;
    scratchCardsAllocated?: number | undefined;
    active: boolean;
    status?: string | undefined;
}
