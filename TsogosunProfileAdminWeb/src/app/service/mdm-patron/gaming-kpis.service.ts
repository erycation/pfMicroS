import { Injectable } from '@angular/core';
import { GamingKPISDeffinitionDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISDeffinitionDto';
import { GamingKPISTSGDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISTSGDto';
import { GamingKPISUnitDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISUnitDto';
import { BackendService } from '../../util/backend.service';



@Injectable({
    providedIn: 'root'
})
export class GamingKPISService {

    constructor(private backend: BackendService) {

    }

    async getGamingKPISDefinitions() {
        return await this.backend.get<GamingKPISDeffinitionDto[]>(`mdm/GamingKPIS/Definitions`);
    }

    async getUnitGamingKPIS(params: any) {
        return await this.backend.get<GamingKPISUnitDto>(`mdm/GamingKPIS/Unit`, params);
    }

    async getTSGGamingKPIS(params: any) {
        return await this.backend.get<GamingKPISTSGDto>(`mdm/GamingKPIS/Tsg`, params);
    }
}