export interface UserDto {
    userID: number;
    siteID: number;
    username?: string | undefined;
    isActive: boolean;
    dateCreated: Date;
    siteFullName?: string | undefined;
    status?: string | undefined;
    firstname?: string | undefined;
    surname?: string | undefined;
}