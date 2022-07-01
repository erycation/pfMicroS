import { ScratchCardDto } from "src/app/model/Dtos/profile-rewards-admin/scratchCardDto";
import { ScratchCardMessageDto } from "src/app/model/Dtos/profile-rewards-admin/scratchCardMessageDto";
import { RankDto } from "src/app/model/loginDto/rankDto";
import { PrizeType } from "src/app/model/profile-admin/prize-type";

export interface ModalConfigurePrizeEntity {
    siteId: string;
    scratchCardDto : ScratchCardDto;
    scratchCardUID: string;
    prizeTypes?: PrizeType[] | undefined;
    ranks?: RankDto[] | undefined;
    scratchCardMessages?: ScratchCardMessageDto[] | undefined;
}