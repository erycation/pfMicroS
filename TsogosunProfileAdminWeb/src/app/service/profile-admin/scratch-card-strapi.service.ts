

import { Injectable } from '@angular/core';
import { ScratchCardStrapi } from 'src/app/model/Dtos/profile-admin/strapiContent/scratchCardStrapi';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class ScratchCardStrapiService {

    constructor(private backend: BackendService) {

    }

    async getScratchCardStrapiImagesByUnit(unitId: string) {
        return await this.backend.get<ScratchCardStrapi[]>(`ScratchCardStrapi/GetAll/${unitId}`);
    }
}
