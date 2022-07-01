import { Injectable } from '@angular/core';
import { GMDocumentTypeDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmDocumentTypeDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class GamesmartDocumentTypeService {

    constructor(private backend: BackendService) {
    }

    async getGMDocumentTypesBySiteId(siteId : string) {
        return await this.backend.get<GMDocumentTypeDto[]>(`GMDocumentType/Get/${siteId}`);
    }
}
