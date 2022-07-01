import { Injectable } from '@angular/core';
import { ScratchCardMessageDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardMessageDto';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class ScratchCardMessageService {

    constructor(private backend: BackendService) {

    }

    async getActiveScratchCardsMessage(siteId: string) {
        return await this.backend.get<ScratchCardMessageDto[]>(`ScratchCardMessage/Active/${siteId}`);
    }

    async getAllScratchCardsMessage(siteId: string ) {
        return await this.backend.get<ScratchCardMessageDto[]>(`ScratchCardMessage/All/${siteId}`);
    }
  }
