import { Injectable } from '@angular/core';
import { GMAddressDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmAddressDto';
import { GMCountryDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmCountryDto';
import { GMProvinceDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmProvinceDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class GamesmartAddressService {

    constructor(private backend: BackendService) {
    }

    async getGMCountriesBySiteId(siteId : string) {
        return await this.backend.get<GMCountryDto[]>(`GMAddress/Country/${siteId}`);
    }

    async getGMProvinceByCountryId(siteId : string, countryId : string) {
        return await this.backend.get<GMProvinceDto[]>(`GMAddress/Province/${siteId}/${countryId}`);
    }

    async getGMAddressByProvince(params: any) {
        return await this.backend.get<GMAddressDto[]>(`GMAddress/Address`, params);
    }
}
