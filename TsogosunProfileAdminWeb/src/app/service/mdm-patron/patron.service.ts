import { Injectable } from '@angular/core';
import { Page } from '../../util/pagedList.model';
import { BackendService } from '../../util/backend.service';
import { PatronDetailsDto } from '../../model/Dtos/mdm-patron/patronDetailsDto';
import { PatronDetailsSiteDto } from '../../model/Dtos/mdm-patron/patronDetailsSiteDto';
import { PatronSitesDto } from '../../model/Dtos/mdm-patron/patronSitesDto';
import { PatronSearchDto } from '../../model/Dtos/mdm-patron/patronSearchDto';
import { PatronStatusSummaryDetailsDto } from '../../model/Dtos/mdm-patron/patronStatusSummaryDetailsDto';
import { SiteDto } from '../../model/loginDto/siteDto';
import { RegisteredOtherSitesDto } from 'src/app/model/Dtos/mdm-patron/registeredOtherSitesDto';


@Injectable({
    providedIn: 'root'
})
export class PatronService {

    constructor(private backend: BackendService) {

    }

    async searchAllPatron(params: any) {
        return await this.backend.get<PatronSearchDto[]>('mdm/Patron/GetAll', params);
    }

    async searchPatron(params: any) {
        return await this.backend.get<Page<PatronSearchDto>>('mdm/Patron', params);
    }

    async getPatronSummaryDetailsBytsogosunID(tsogosunID: string) {
        return await this.backend.get<PatronStatusSummaryDetailsDto>(`mdm/Patron/Get/Summary/${tsogosunID}`);
    }
  
    async getPatronBytsogosunID(tsogosunID: string) {
        return await this.backend.get<PatronDetailsDto>(`mdm/Patron/Get/${tsogosunID}`);
    }

    async getPatronSitesBytsogosunID(tsogosunID: string) {
        return await this.backend.get<PatronSitesDto[]>(`mdm/Patron/Get/Sites/${tsogosunID}`);
    }

    async getPatronActiveSitesByUserSites(tsogosunID: string, userSites: SiteDto[]) {
        return await this.backend.postResponse<SiteDto[]>(`mdm/Patron/ActiveSites/${tsogosunID}`, userSites);
    }

    async getPatronBySiteIdAndTsogosunID(siteId : string, patronNumber: string, tsogosunID: string) {
        return await this.backend.get<PatronDetailsSiteDto>(`mdm/Patron/Sites/PatronNumber/${siteId}/${patronNumber}/${tsogosunID}`);
    } 

    async patronRegisteredOtherSites(idNumber: string) {
        return await this.backend.get<RegisteredOtherSitesDto>(`mdm/Patron/RegisteredSite/${idNumber}`);
    }
}

