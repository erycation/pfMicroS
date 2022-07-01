import { Injectable } from '@angular/core';
import { Page } from '../../util/pagedList.model';
import { BackendService } from '../../util/backend.service';
import { GamingPointsTSGDto } from 'src/app/model/Dtos/mdm-patron/gamingPointsTSGDto';
import { GamingPointsUnitDto } from 'src/app/model/Dtos/mdm-patron/gamingPointsUnitDto';


@Injectable({
    providedIn: 'root'
})
export class GamingPointsService {

    constructor(private backend: BackendService) {

    }

    async getTSGGamingPoints(tsogosunID: string) {
        return await this.backend.get<GamingPointsTSGDto>(`mdm/GamingPoints/TSG/${tsogosunID}`);
    }

    async getUnitGamingPoints(siteId: string, patronNumber: string) {
        return await this.backend.get<GamingPointsUnitDto>(`mdm/GamingPoints/Unit/${siteId}/${patronNumber}`);
    }

}