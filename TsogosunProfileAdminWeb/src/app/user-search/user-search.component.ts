import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDto } from '../model/Dtos/profile-admin/userDto';
import { RequestUser } from '../model/request/profile-admin/requestUser';
import { AccountService } from '../service/account.service';
import { UserService } from '../service/profile-admin/user-service';
import { DialogService } from '../shared/dialog/dialog.service';
import { ModalResetParams } from '../shared/modal-reset-params';
import { SectionUtility } from '../shared/section-utility';
import { SharedFunction } from '../shared/shared-function';

@Component({
  selector: 'app-user-search',
  templateUrl: './user-search.component.html',
  styleUrls: ['./user-search.component.css']
})
export class UserSearchComponent extends ModalResetParams implements OnInit {

  requestUser = {} as RequestUser;
  usersDto: UserDto[] = [];
  usersDtoItems: Array<UserDto>;

  constructor(accountService: AccountService,
              sharedFunction: SharedFunction,
              router: Router,
              private userService: UserService,    
              private dialogService: DialogService) {
      super(accountService,
        sharedFunction,
        router,
        SectionUtility.UserMaintanance); 

  }

  async ngOnInit() {

    if(this.userSites[0] != null)
    {
      this.requestUser.unitId = this.userSites[0].siteID;
    }
  }

  async searchUsers() {

    this.resetValidationFields();
    if(!SharedFunction.checkUndefinedObjectValue(this.requestUser.unitId))
    {
      this.dialogService.openAlertModal("Alert","Please select Unit", ()=>{ });
      return;
    }

    this.usersDto = await this.userService.getAllUsers(this.requestUser);

    if(this.usersDto?.length == 0)
    {
        this.displayNoResultsMessage();
    } 
  }

  goToModifyUser(user : UserDto) {
    this.goToPageOneParams('modify-user', user.userID);
  }

  async AddUser()
  {
    this.goToPageNoParams('add-user');
  }

  onChangePage(pageOfItems: Array<UserDto>) {
    // update current page of items
    this.usersDtoItems = pageOfItems;
  }
}
