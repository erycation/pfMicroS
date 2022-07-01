import { Site } from "./site";
import { UserPermission } from "./userPermission";

export interface User {
    userID: number;
    siteID: number;
    username?: string | undefined;
    firstname?: string | undefined;
    surname?: string | undefined;
    isActive: boolean;
    dateCreated: Date;
    site?: Site | undefined;
    userPermissions?: UserPermission[] | undefined;
    status?: string | undefined;
}