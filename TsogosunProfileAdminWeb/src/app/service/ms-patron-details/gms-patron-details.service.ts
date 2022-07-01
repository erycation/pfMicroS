import { Injectable } from '@angular/core';
import { GMSPatronDetails } from 'src/app/model/Dtos/ms-patron-details/gmsPatronDetails';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class GMSPatronDetailsService {

    constructor(private backend: BackendService) {
    }

    async addGMSPatronDetails(gmsPatronDetails: GMSPatronDetails) {
        return this.backend.postResponse<any>(`GMSPatronDetails/Add`, gmsPatronDetails);
    }
}

