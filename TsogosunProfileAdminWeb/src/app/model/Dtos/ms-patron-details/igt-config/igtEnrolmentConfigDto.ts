export interface IGTEnrolmentConfigDto {
    siteID: number;
    enrolIGTUserID: number;
    enrolIGTLoginName?: string | undefined;
    enrolIGTFirstName?: string | undefined;
    enrolIGTLastName?: string | undefined;
    enrolIGTLicense?: string | undefined;
}