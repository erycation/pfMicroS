import { Application } from "./application";
import { UserPermission } from "./userPermission";

export interface ApplicationSection {
    sectionID: number;
    applicationID: number;
    sectionName?: string | undefined;
    websiteSectionRoute?: string | undefined;
    isMenuItem: boolean;
    isActive: boolean;
    referenceName?: string | undefined;
    application?: Application | undefined;
    userPermissions?: UserPermission[] | undefined;
    status?: string | undefined;
}