import { Injectable } from '@angular/core';
import { PrizeTypeDto } from 'src/app/model/Dtos/profile-rewards-admin/prizeTypeDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class PrizeTypeService {

    constructor(private backend: BackendService) {

    }

    async getAllPrizeTypesBySiteId(siteId: string) {
        return await this.backend.get<PrizeTypeDto[]>(`PrizeType/All/${siteId}`);
    }
    
}
