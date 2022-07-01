import { LeaderBoardPromotionDto } from "../../Dtos/profile-rewards-admin/leaderBoardPromotionDto";

export interface RequestAddUpdateLeaderBoard {
    startTime?: string | undefined;
    endTime?: string | undefined;
    leaderBoardPromotionDto?: LeaderBoardPromotionDto | undefined;
}