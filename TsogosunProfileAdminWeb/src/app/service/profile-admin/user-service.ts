import { Injectable } from '@angular/core';
import { TitleDto } from 'src/app/model/Dtos/profile-admin/titleDto';
import { UserApplicationSectionDto } from 'src/app/model/Dtos/profile-admin/userApplicationSectionDto';
import { UserDto } from 'src/app/model/Dtos/profile-admin/userDto';
import { User } from 'src/app/model/profile-admin/user';
import { RequestUser } from 'src/app/model/request/profile-admin/requestUser';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private backend: BackendService) {

    }

    async getUserByUserUd(userId: string) {
        return await this.backend.get<UserDto>(`User/Get/${userId}`);
    }

    async getAllUsers(params: any) {
        return await this.backend.get<UserDto[]>('User/GetAll', params);
    }

    async getUsersByUnit(unitId : string) {
        return await this.backend.get<UserDto[]>(`User/GetAll/${unitId}`);
    }

    async getUserTitles() {
        return await this.backend.get<TitleDto[]>(`User/Titles`);
    }

    async addUser(user: User, permisionGroupId : number) {
        return this.backend.postResponse<any>(`User/Add/${permisionGroupId}`, user);
     }
     

     async updateUser(userDto: UserDto) {
        return this.backend.postResponse<any>(`User/Update`, userDto);
    }

     async getUserApplicationSectionByUserId(userId : number) {
        return await this.backend.get<UserApplicationSectionDto>(`User/Application/Section/${userId}`);
     }
}

