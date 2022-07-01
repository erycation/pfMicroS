import { Injectable } from '@angular/core';
import { IGTEnrolmentConfigDto } from 'src/app/model/Dtos/ms-patron-details/igt-config/igtEnrolmentConfigDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class IGTEnrolmentConfigService {

    constructor(private backend: BackendService) {
    }

    async getIGTEnrolmentConfigBySiteId(siteId: string) {
        return await this.backend.get<IGTEnrolmentConfigDto>(`IGTEnrolmentConfig/Get/${siteId}`);
    }

 }
