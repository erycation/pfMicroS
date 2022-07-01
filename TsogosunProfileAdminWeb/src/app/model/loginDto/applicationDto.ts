import { SectionDto } from "./sectionDto";

export interface ApplicationDto {
    applicationId: number;
    applicationName?: string | undefined;
    websiteRoute?: string | undefined;
    isApplicationMenuItem: boolean;
    sections?: SectionDto[] | undefined;
}