import { Injectable } from '@angular/core';
import { DefaultPermissionGroup } from 'src/app/model/profile-admin/defaultPermissionGroup';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class PermissionGroupService {

    constructor(private backend: BackendService) {

    }

    async getAllDefaultPermissionGroup() {
        return await this.backend.get<DefaultPermissionGroup[]>(`DefaultPermissionGroup/All`);
    }

    async getActiveDefaultPermissionGroup(siteId : number) {
        return await this.backend.get<DefaultPermissionGroup[]>(`DefaultPermissionGroup/Active/${siteId}`);
    } 
}

