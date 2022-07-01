import { Injectable } from '@angular/core';
import { LogFilesDto } from 'src/app/model/Dtos/profile-admin/logFilesDto';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class AuditLogsService {

    constructor(private backend: BackendService) {

    }

    async getLogFiles() {
        return await this.backend.get<LogFilesDto[]>(`AuditLogs/GetAll`);
    }

    async clearLogFiles() {
        return await this.backend.postWithResponse<any>(`AuditLogs/Clear`, null);
    }
}

