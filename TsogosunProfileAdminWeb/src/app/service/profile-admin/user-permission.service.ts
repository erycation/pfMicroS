import { Injectable } from '@angular/core';
import { UserPermission } from 'src/app/model/profile-admin/userPermission';
import { BackendService } from 'src/app/util/backend.service';

@Injectable({
    providedIn: 'root'
})
export class UserPermissionService {

    constructor(private backend: BackendService) {

    }

    async addUserPermissionGroup(userPermission: UserPermission) {
        return await this.backend.postWithResponse<any>(`UserPermission/Add`, userPermission);
    }

    async deactivateUserPermissionGroup(userPermission: UserPermission) {
        return await this.backend.postWithResponse<any>(`UserPermission/Deactivate`, userPermission);
    }
}