import { SiteDto } from "./siteDto";

export interface SectionDto {
    sectionId: number;
    sectionName?: string | undefined;
    isSectionMenuItem: boolean;
    websiteSectionRoute?: string | undefined;
    referenceName?: string | undefined;
    sites?: SiteDto[] | undefined;
}