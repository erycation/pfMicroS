

import { Injectable } from '@angular/core';
import { RequestAddUpdatePlayerProfile } from 'src/app/model/request/igt-gaming-system/request-add-updatePlayerProfile';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class IGTGamingAreaService {

    constructor(private backend: BackendService) {

    }

    async createGamingAreaAccountIGT(requestAddUpdatePlayerProfile: RequestAddUpdatePlayerProfile) {
        return this.backend.postResponse<any>(`IGT/PlayerProfile/Add`, requestAddUpdatePlayerProfile);
     }

}
