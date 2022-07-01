import { Injectable } from '@angular/core';
import { GamingAreaDto } from 'src/app/model/Dtos/profile-rewards-admin/gamingAreaDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class GamingAreasService {

    constructor(private backend: BackendService) {

    }

    async getAllGamingAreasBySiteId(siteId: string) {
        return await this.backend.get<GamingAreaDto[]>(`GamingArea/All/${siteId}`);
    }
    
}
