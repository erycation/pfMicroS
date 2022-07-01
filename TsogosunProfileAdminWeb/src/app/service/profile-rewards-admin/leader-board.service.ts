import { Injectable } from '@angular/core';
import { LeaderBoardPatronDto } from 'src/app/model/Dtos/profile-rewards-admin/leaderBoardPatronDto';
import { LeaderBoardPromotionDto } from 'src/app/model/Dtos/profile-rewards-admin/leaderBoardPromotionDto';
import { RequestAddUpdateLeaderBoard } from 'src/app/model/request/profile-rewards-admin/requestAddUpdateLeaderBoard';

import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class LeaderBoardService {

    constructor(private backend: BackendService) {

    }

    async addLeaderBoardPromotion(requestAddUpdateLeaderBoard: RequestAddUpdateLeaderBoard) {
        return this.backend.postResponse<any>(`LeaderBoard/Add`, requestAddUpdateLeaderBoard);
    }

    async updateLeaderBoardPromotion(requestAddUpdateLeaderBoard: RequestAddUpdateLeaderBoard) {
        return this.backend.postResponse<any>(`LeaderBoard/Update`, requestAddUpdateLeaderBoard);
    }

    async getLeaderBoardPromotionsBySiteId(siteId: string, params: any) {
        return await this.backend.get<LeaderBoardPromotionDto[]>(`LeaderBoard/All/${siteId}`, params);
    }

    async getLeaderBoardByPromotion(siteId: string, promotionId: string) {
        return await this.backend.get<LeaderBoardPromotionDto>(`LeaderBoard/Get/${siteId}/${promotionId}`);
    }
    
    async getLeaderBoardByPatrons(siteId: string, patronNo: string) {
        return await this.backend.get<LeaderBoardPatronDto[]>(`LeaderBoard/Patron/${siteId}/${patronNo}`);
    }
    
}
