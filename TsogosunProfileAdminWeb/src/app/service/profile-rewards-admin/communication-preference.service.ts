import { Injectable } from '@angular/core';
import { CommunicationPreferenceDto } from 'src/app/model/Dtos/profile-rewards-admin/communicationPreferenceDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class CommunicationPreferenceService {

    constructor(private backend: BackendService) {

    }

    async getAllCommunicationPreferencesByPatron(patronNo: string, siteId: string) {
        return await this.backend.get<CommunicationPreferenceDto[]>(`CommunicationPreference/All/${patronNo}/${siteId}`);
    }    
}
