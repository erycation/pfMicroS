import { Injectable } from '@angular/core';
import { CityDto } from 'src/app/model/Dtos/profile-admin/cityDto';
import { CountryDto } from 'src/app/model/Dtos/profile-admin/countryDto';
import { PostalCodeDto } from 'src/app/model/Dtos/profile-admin/postalCodeDto';
import { ProvinceDto } from 'src/app/model/Dtos/profile-admin/provinceDto';
import { SuburbDto } from 'src/app/model/Dtos/profile-admin/suburbDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class CountryService {

    constructor(private backend: BackendService) {

    }

    async getCountries() {
        return await this.backend.get<CountryDto[]>(`Country/GetAll`);
    }

    async getProvincesByName(name: string) {
        return await this.backend.get<ProvinceDto[]>(`Country/Province/Get/${name}`);
    }

    async getPostalCodesByCode(name: string) {
        return await this.backend.get<PostalCodeDto[]>(`Country/PostalCode/Get/${name}`);
    }

    async getCityByName(name: string) {
        return await this.backend.get<CityDto[]>(`Country/City/Get/${name}`);
    }

    async getSuburbByName(name: string) {
        return await this.backend.get<SuburbDto[]>(`Country/Suburb/Get/${name}`);
    }
}
