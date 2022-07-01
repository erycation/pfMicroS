

import { Injectable } from '@angular/core';
import { LeaderBoardStrapi } from 'src/app/model/Dtos/profile-admin/strapiContent/leaderBoardStrapi';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class LeaderBoardStrapiService {

    constructor(private backend: BackendService) {

    }

    async getLeaderBoardStrapiImagesByUnit(unitId: string) {
        return await this.backend.get<LeaderBoardStrapi[]>(`LeaderBoardStrapi/GetAll/${unitId}`);
    }
}
