import { Injectable } from '@angular/core';
import { ScratchCardActiveTimesDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardActiveTimesDto';
import { RequestAddUpdateScratchCardActiveTime } from 'src/app/model/request/profile-rewards-admin/requestAddUpdateScratchCardActiveTime';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class ScratchCardActiveTimesService {

    constructor(private backend: BackendService) {

    }

    async getScratchCardActiveTimesByscratchCardId(siteId: string, scratchCardId : string) {
        return await this.backend.get<ScratchCardActiveTimesDto[]>(`ScratchCardActiveTime/All/${siteId}/${scratchCardId}`);
    }

    async addScratchCardActiveTimes(requestAddUpdateScratchCardActiveTime: RequestAddUpdateScratchCardActiveTime, siteId : string) {
        return this.backend.postResponse<any>(`ScratchCardActiveTime/Add/${siteId}`, requestAddUpdateScratchCardActiveTime);
     }

     async updateScratchCardActiveTimes(requestAddUpdateScratchCardActiveTime: RequestAddUpdateScratchCardActiveTime, siteId : string) {
        return this.backend.postResponse<any>(`ScratchCardActiveTime/Update/${siteId}`, requestAddUpdateScratchCardActiveTime);
     }
    
  }
