import { ApplicationDto } from "../../loginDto/applicationDto";
import { UserRightsSectionDto } from "../../loginDto/user-rights-sectionDto";
import { UserDto } from "./userDto";

export interface UserApplicationSectionDto extends UserRightsSectionDto {
    userDto?: UserDto | undefined;
    applications?: ApplicationDto[] | undefined;
}