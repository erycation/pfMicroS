import { ScratchCardActiveTimesDto } from "src/app/model/Dtos/profile-rewards-admin/scratchCardActiveTimesDto";
import { StatusDto } from "src/app/model/loginDto/statusDto";

export interface AddActiveDateModal  {

    siteId: string;
    scratchCardStartDateNumber : number;
    scratchCardEndDateNumber : number;
    scratchCardActiveTimesDto : ScratchCardActiveTimesDto;
    statusItems?: StatusDto[] | undefined;

}