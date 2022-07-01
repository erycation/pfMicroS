import { ScratchCardPrizeDto } from "src/app/model/Dtos/profile-rewards-admin/scratchCardPrizeDto";
import { ConfigurePriceModal } from "../configure-price-modal/configure-price-modal";


export interface UpdateConfigurePriceModal extends ConfigurePriceModal {

    scratchCardPrizeDto?: ScratchCardPrizeDto | undefined;
    
}