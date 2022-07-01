import { Injectable } from '@angular/core';
import { CityDto } from 'src/app/model/Dtos/profile-admin/cityDto';
import { CountryDto } from 'src/app/model/Dtos/profile-admin/countryDto';
import { IGTCountryDto } from 'src/app/model/Dtos/profile-admin/igt-patron-details/igtCountryDto';
import { PostalCodeDto } from 'src/app/model/Dtos/profile-admin/postalCodeDto';
import { ProvinceDto } from 'src/app/model/Dtos/profile-admin/provinceDto';
import { SuburbDto } from 'src/app/model/Dtos/profile-admin/suburbDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class IGTCountryService {

    constructor(private backend: BackendService) {

    }

    async getIGTCountryByName(siteId : string, countryName : string) {
        return await this.backend.get<IGTCountryDto>(`Country/GetAll`);
    }
}
