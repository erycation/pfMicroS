import { PlayerProfile } from "../../igt-gaming-system/playerProfile";
import { HasSiteId } from "../../shared/hasSiteId";

export interface RequestAddUpdatePlayerProfile extends HasSiteId {
    playerProfile?: PlayerProfile | undefined;
}