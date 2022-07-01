import { Injectable } from '@angular/core';
import { IGTCountryDto } from 'src/app/model/Dtos/profile-admin/igt-config/igtCountryDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class IGTConfigurationService {

    constructor(private backend: BackendService) {
    }

    async getIGTCountryByName(siteId : string, countryName : string) {
        return await this.backend.get<IGTCountryDto>(`IGTConfiguration/Country/${siteId}/${countryName}`);
    }
}
