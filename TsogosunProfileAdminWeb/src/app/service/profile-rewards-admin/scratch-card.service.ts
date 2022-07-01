import { Injectable } from '@angular/core';
import { PatronScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/patronScratchCardDto';
import { ScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardDto';
import { ScratchCardOverViewDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardOverViewDto';
import { ScratchCardWinnersDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardWinnersDto';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class ScratchCardService {

    constructor(private backend: BackendService) {

    }

    async getScratchCardsByUID(scratchCardUID : string, siteId: string) {
        return await this.backend.get<ScratchCardDto>(`ScratchCard/${scratchCardUID}/${siteId}`);
    }

    async getScratchCardsBySiteId(siteId: string) {
        return await this.backend.get<ScratchCardDto[]>(`ScratchCard/All/${siteId}`);
    }

    async getScratchCardsByPatronNumber(siteId: string,patronNumber : string ) {
        return await this.backend.get<PatronScratchCardDto[]>(`ScratchCard/Get/${siteId}/${patronNumber}`);
    }
    
    async getScratchCardOverviewBySiteId(siteId: string, params: any) {
        return await this.backend.get<ScratchCardOverViewDto[]>(`ScratchCard/Overview/${siteId}`, params);
    }

    async getScratchCardForWinners(siteId: string, params: any) {
        return await this.backend.get<ScratchCardDto[]>(`ScratchCard/Winners/ScratchCard/${siteId}`, params);
    }

    async downloadPDFReportWinners(scratchCardHeader : any) {
        await this.backend.downloadFilePDF(`ScratchCard/WinnerReport/pdf`, scratchCardHeader);
    }

    async downloadExcelReportWinners(scratchCardHeader : any) {
        await this.backend.downloadFileExcel(`ScratchCard/WinnerReport/excel`, scratchCardHeader);
    }

    async getScratchCardWinners(scratchCardHeader : any) {
        return await this.backend.get<ScratchCardWinnersDto[]>(`ScratchCard/Winners/Report`, scratchCardHeader);
    }
    
    async addScratchCard(scratchCardDto: ScratchCardDto) {
        return this.backend.postResponse<any>(`ScratchCard/Add`, scratchCardDto);
     }

     async updateScratchCard(scratchCardDto: ScratchCardDto) {
        return this.backend.postResponse<any>(`ScratchCard/Update`, scratchCardDto);
     }
  }
