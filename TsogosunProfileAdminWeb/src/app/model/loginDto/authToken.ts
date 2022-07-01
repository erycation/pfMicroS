import { NavItem } from "src/app/shared/menu-list-item/nav-item";
import { PrizeType } from "../profile-admin/prize-type";
import { ApplicationDto } from "./applicationDto";
import { GenderDto } from "./genderDto";
import { PointsTypeDto } from "./pointsTypeDto";
import { RankDto } from "./rankDto";
import { StatusDto } from "./statusDto";
import { UserRightsSectionDto } from "./user-rights-sectionDto";

export interface AuthToken extends UserRightsSectionDto {
    userId: number;
    userSessionId?: string | undefined;
    username?: string | undefined;
    success: boolean;
    message?: string | undefined;
    token?: string | undefined;
    applications?: ApplicationDto[] | undefined;
    navItems?: NavItem[] | undefined;
    statusItems?: StatusDto[] | undefined;
    prizeTypes?: PrizeType[] | undefined;
    ranks?: RankDto[] | undefined;
    pointsTypes?: PointsTypeDto[] | undefined;
    genders?: GenderDto[] | undefined;
    
}