import { Application } from "./application";

export interface Connection {
    connectionID: number;
    connectionName?: string | undefined;
    dataSource?: string | undefined;
    initialCatalog?: string | undefined;
    dBUserID?: string | undefined;
    password?: string | undefined;
    isActive: boolean;
    applications?: Application[] | undefined;
    status?: string | undefined;
}