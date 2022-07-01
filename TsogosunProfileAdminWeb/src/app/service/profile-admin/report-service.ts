import { Injectable } from '@angular/core';
import { DrawAvailableDto } from 'src/app/model/Dtos/profile-admin/drawAvailableDto';
import { DrawRedeemedDto } from 'src/app/model/Dtos/profile-admin/drawRedeemedDto';
import { FreePlayAvailableDto } from 'src/app/model/Dtos/profile-admin/freePlayAvailableDto';
import { FreePlayRedeemedDto } from 'src/app/model/Dtos/profile-admin/freePlayRedeemedDto';
import { PatronDrawDto } from 'src/app/model/Dtos/profile-admin/patronDrawDto';
import { PatronFreePlayDto } from 'src/app/model/Dtos/profile-admin/patronFreePlayDto';
import { PatronVoucherDto } from 'src/app/model/Dtos/profile-admin/patronVoucherDto';
import { VoucherAvailableDto } from 'src/app/model/Dtos/profile-admin/voucherAvailableDto';
import { VoucherRedeemedDto } from 'src/app/model/Dtos/profile-admin/voucherRedeemedDto';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class ReportService {

    constructor(private backend: BackendService) {

    }

    async getPatronFreePlays(params: any) {
        return await this.backend.get<PatronFreePlayDto[]>(`Report/AvailablePatronFreePlay`, params);
    }

    async getPatronVouchers(params: any) {
        return await this.backend.get<PatronVoucherDto[]>(`Report/AvailablePatronVoucher`, params);
    }

    async getPatronDraws(params: any) {
        return await this.backend.get<PatronDrawDto[]>(`Report/AvailablePatronDraw`, params);
    }




    


    async getRedeemedVouchers(params: any) {
        return await this.backend.get<VoucherRedeemedDto[]>('Report/RedeemedVoucher', params);
    }

    async getAvailableVouchers(siteId : string, patronNumber : string) {
        return await this.backend.get<VoucherAvailableDto[]>(`Report/AvailableVoucher/${siteId}/${patronNumber}`);
    }    

    async getRedeemedFreePlays(params: any) {
        return await this.backend.get<FreePlayRedeemedDto[]>('Report/RedeemedFreePlay', params);
    }

    async getAvailableFreePlays(siteId : string, patronNumber : string) {
        return await this.backend.get<FreePlayAvailableDto[]>(`Report/AvailableFreePlay/${siteId}/${patronNumber}`);
    }

    async getRedeemedDraws(params: any) {
        return await this.backend.get<DrawRedeemedDto[]>('Report/RedeemedDraw', params);
    }

    async getAvailableDraws(siteId : string, patronNumber : string) {
        return await this.backend.get<DrawAvailableDto[]>(`Report/AvailableDraw/${siteId}/${patronNumber}`);
    } 
}

