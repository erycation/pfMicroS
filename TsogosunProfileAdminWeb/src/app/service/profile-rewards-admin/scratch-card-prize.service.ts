import { Injectable } from '@angular/core';
import { ScratchCardPrizeDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardPrizeDto';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class ScratchCardPrizeService {

    constructor(private backend: BackendService) {

    }

    async getScratchCardPrizeByScratchCardId(scratchCardId : string, siteId: string) {
        return await this.backend.get<ScratchCardPrizeDto[]>(`ScratchCardPrize/All/${scratchCardId}/${siteId}`);
    }

    async addScratchCardPrize(scratchCardPrizeDto: ScratchCardPrizeDto) {
        return this.backend.postResponse<any>(`ScratchCardPrize/Add`, scratchCardPrizeDto);
     }

     async updateScratchCardPrize(scratchCardPrizeDto: ScratchCardPrizeDto) {
        return this.backend.postResponse<any>(`ScratchCardPrize/Update`, scratchCardPrizeDto);
     }

  }
