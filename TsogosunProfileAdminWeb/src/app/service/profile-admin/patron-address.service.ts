import { Injectable } from '@angular/core';
import { PatronAddressSearchDto } from 'src/app/model/Dtos/ms-patron-details/patronAddressSearchDto';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class PatronAddressService {

    constructor(private backend: BackendService) {
    }

    async getPatronAddress(params: any) {
        return await this.backend.get<PatronAddressSearchDto[]>(`PatronAddress/GetAll`, params);
    } 
}

