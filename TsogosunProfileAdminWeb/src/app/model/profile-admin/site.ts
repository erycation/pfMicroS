import { UserPermission } from "./userPermission";

export interface Site {
    siteID: number;
    siteName?: string | undefined;
    siteFullName?: string | undefined;
    isActive: boolean;
    userPermissions?: UserPermission[] | undefined;
    status?: string | undefined;
}