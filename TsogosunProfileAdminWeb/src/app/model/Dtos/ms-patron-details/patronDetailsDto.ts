import { PatronDetailsInfo } from "./patron-Info-Details/patronDetailsInfo";

export interface PatronDetailsDto extends PatronDetailsInfo {
    siteId:number;
    status?: string | undefined;
    createdDate?: Date | undefined;
    recordStatus?: string | undefined;
    allocatedUser?: string | undefined;    
}