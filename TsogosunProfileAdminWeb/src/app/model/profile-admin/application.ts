import { ApplicationSection } from "./applicationSection";
import { Connection } from "./connection";
import { UserPermission } from "./userPermission";

export interface Application {
    applicationID: number;
    applicationName?: string | undefined;
    isMenuItem: boolean;
    websiteRoute?: string | undefined;
    isActive: boolean;
    applicationSections?: ApplicationSection[] | undefined;
    userPermissions?: UserPermission[] | undefined;
    connections?: Connection[] | undefined;
    status?: string | undefined;
}
