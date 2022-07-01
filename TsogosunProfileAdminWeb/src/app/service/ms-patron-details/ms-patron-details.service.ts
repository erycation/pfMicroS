import { Injectable } from '@angular/core';
import { ApprovedUserDetailsDto } from 'src/app/model/Dtos/ms-patron-details/approvedUserDetailsDto';
import { IGTConfirmedPatronDetailsDto } from 'src/app/model/Dtos/ms-patron-details/igtConfirmedPatronDetailsDto';
import { ConfirmPlayerToSubmitGamingDto } from 'src/app/model/Dtos/ms-patron-details/confirmPlayerToSubmitGamingDto';
import { GMSConfirmedPatronDetailsDto } from 'src/app/model/Dtos/ms-patron-details/gmsConfirmedPatronDetailsDto';
import { PatronDetailsDto } from 'src/app/model/Dtos/ms-patron-details/patronDetailsDto';
import { PatronDetailsInfoDto } from 'src/app/model/Dtos/ms-patron-details/patronDetailsInfoDto';
import { UnconfirmedGMSPatronDetailsInfoDto } from 'src/app/model/Dtos/ms-patron-details/unconfirmedGMSPatronDetailsInfoDto';
import { UnconfirmedIGTPatronDetailsInfoDto } from 'src/app/model/Dtos/ms-patron-details/unconfirmedIGTPatronDetailsInfoDto';
import { RequestUpdatePatronStatus } from 'src/app/model/request/ms-patron-details/requestUpdatePatronStatus';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class MSPatronDetailsService {

    constructor(private backend: BackendService) {
    }

    async getPatronDetailsBySiteID(params: any) {
        return await this.backend.get<PatronDetailsDto[]>(`PatronDetails/Get`, params);
    }

    async updatePatronStatus(requestUpdatePatronStatus: RequestUpdatePatronStatus) {
        return this.backend.postResponse<any>(`PatronDetails/Update/Status`, requestUpdatePatronStatus);
    }

    //to be deleted
    async getPatronDetailsByUserId(userId: string, siteId: string) {
        return await this.backend.get<PatronDetailsInfoDto>(`PatronDetails/Info/Get/${userId}/${siteId}`);
    }

    async getUnconfirmedIGTPatronDetailsByUserId(userId: string) {
        return await this.backend.get<UnconfirmedIGTPatronDetailsInfoDto>(`PatronDetails/Unconfirmed/IGT/${userId}`);
    }

    async getUnconfirmedGamesmartPatronDetailsByUserId(userId: string) {
        return await this.backend.get<UnconfirmedGMSPatronDetailsInfoDto>(`PatronDetails/Unconfirmed/gamesmart/${userId}`);
    }
//to be remove
    async updatePatronDetails(patronDetailsInfoDto: PatronDetailsInfoDto) {
        return this.backend.postResponse<any>(`PatronDetails/Update/Info`, patronDetailsInfoDto);
    }

    async updateUnconfirmGamesmartPatronDetails(unconfirmedGMSPatronDetailsInfoDto: UnconfirmedGMSPatronDetailsInfoDto) {
        return this.backend.postResponse<any>(`PatronDetails/Update/Unconfirmed/Gamesmart`, unconfirmedGMSPatronDetailsInfoDto);
    }

    async updateUnconfirmIGTPatronDetails(unconfirmedIGTPatronDetailsInfoDto: UnconfirmedIGTPatronDetailsInfoDto) {
        return this.backend.postResponse<any>(`PatronDetails/Update/Unconfirmed/Igt`, unconfirmedIGTPatronDetailsInfoDto);
    }

    async updatePatronAddress(patronDetailsInfoDto: PatronDetailsInfoDto) {
        return this.backend.postResponse<any>(`PatronDetails/Update/Address`, patronDetailsInfoDto);
    } 

    async getConfirmedPatronDetailsFromGamesmartByUserId(userId: string, siteId: string) {
        return await this.backend.get<GMSConfirmedPatronDetailsDto>(`PatronDetails/Confirmed/Gamesmart/${userId}/${siteId}`);
    }
    
    async getConfirmedPatronDetailsFromIGTByUserId(userId: string) {
        return await this.backend.get<IGTConfirmedPatronDetailsDto>(`PatronDetails/Confirmed/Igt/${userId}`);
    }

    async getApprovedPatroRegistrationBySiteID(siteId: any) {
        return await this.backend.get<ApprovedUserDetailsDto[]>(`PatronDetails/Approved/GetAll/${siteId}`);
    }

    async confirmPlayerStatusAfterSubmitGaming(confirmPlayerToSubmitGamingDto: ConfirmPlayerToSubmitGamingDto) {
        return this.backend.postResponse<any>(`PatronDetails/Gaming/Confirm/Status`, confirmPlayerToSubmitGamingDto);
    }
}

