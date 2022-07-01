import { PrizeTypeDto } from "src/app/model/Dtos/profile-rewards-admin/prizeTypeDto";
import { RankDto } from "src/app/model/loginDto/rankDto";

export interface ConfigurePriceModal {
    siteId: string;
    siteFullName: string;
    scratchCardUID: string;
    prizeTypes?: PrizeTypeDto[] | undefined;
    ranks?: RankDto[] | undefined;
}