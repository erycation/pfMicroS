import { Application } from "./application";
import { ApplicationSection } from "./applicationSection";
import { Site } from "./site";
import { User } from "./user";

export interface UserPermission {
    userPermissionId: number;
    userID: number;
    applicationID: number;
    applicationSectionID: number;
    siteID: number;
    isActive: boolean;
    dateInserted: Date;
    application?: Application | undefined;
    applicationSection?: ApplicationSection | undefined;
    site?: Site | undefined;
    user?: User | undefined;
}