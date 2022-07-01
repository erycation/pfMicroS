export interface ScratchCardActiveTimesDto {
    scratchCardReleaseID: number;
    scratchCardUID: string;
    startDateTime: any;
    endDateTime: any;
    dateinserted: Date;
    isActive: boolean;
    status?: string | undefined;
    startTime?: string | undefined;
    endTime?: string | undefined;
   
}