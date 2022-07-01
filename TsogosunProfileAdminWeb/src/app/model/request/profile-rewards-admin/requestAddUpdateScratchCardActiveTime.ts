import { ScratchCardActiveTimesDto } from "../../Dtos/profile-rewards-admin/scratchCardActiveTimesDto";

export interface RequestAddUpdateScratchCardActiveTime {
    startTime?: string | undefined;
    endTime?: string | undefined;
    scratchCardActiveTimesDto?: ScratchCardActiveTimesDto | undefined;
}