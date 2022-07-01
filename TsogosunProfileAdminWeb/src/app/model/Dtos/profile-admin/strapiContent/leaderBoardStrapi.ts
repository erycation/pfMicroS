import { ImageDetailsDto } from "./leaderBoardImages/imageDetailsDto";

export interface LeaderBoardStrapi {
    id: number;
    title?: string | undefined;
    startDate?: Date | undefined;
    endDate?: Date | undefined;
    order?: string | undefined;
    tier?: string | undefined;
    created_At?: Date | undefined;
    updated_At?: Date | undefined;
    image?: ImageDetailsDto | undefined;
}