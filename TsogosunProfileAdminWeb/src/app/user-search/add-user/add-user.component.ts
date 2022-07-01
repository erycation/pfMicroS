import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DefaultPermissionGroup } from 'src/app/model/profile-admin/defaultPermissionGroup';
import { User } from 'src/app/model/profile-admin/user';
import { AccountService } from 'src/app/service/account.service';
import { PermissionGroupService } from 'src/app/service/profile-admin/permission-group.service';
import { UserService } from 'src/app/service/profile-admin/user-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent extends ModalResetParams implements OnInit {

  adduser = {} as User;
  defaultPermissionGroups: DefaultPermissionGroup[] = [];
  defaultPermissionGroup = {} as DefaultPermissionGroup;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private userService: UserService,
    private permissionGroupService: PermissionGroupService,
    private dialogService: DialogService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.UserMaintanance);
  }

  async ngOnInit() {

    if (SharedFunction.checkUndefinedObjectValue(this.userSites[0])) {
      this.adduser.siteID = this.userSites[0].siteID;
      this.defaultPermissionGroups = await this.permissionGroupService.getActiveDefaultPermissionGroup(this.adduser.siteID);
    }
  }

  async loadActiveDefaultPermissionGroup() {
    this.defaultPermissionGroup = null;
    this.defaultPermissionGroups = [];
    this.defaultPermissionGroups = await this.permissionGroupService.getActiveDefaultPermissionGroup(this.adduser.siteID);
    if (SharedFunction.checkUndefinedObjectValue(this.defaultPermissionGroups[0])) {
      this.defaultPermissionGroup = this.defaultPermissionGroups[0];
    }
  }

  async saveAndContinue() {
    if (!SharedFunction.checkUndefinedObjectValue(this.adduser.siteID)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.adduser.username)) {
      this.dialogService.openAlertModal("Alert", "Please enter username", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.adduser.firstname)) {
      this.dialogService.openAlertModal("Alert", "Please enter firstname", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.adduser.surname)) {
      this.dialogService.openAlertModal("Alert", "Please enter surname", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.defaultPermissionGroup)) {
      this.dialogService.openAlertModal("Alert", "Please select permision group", () => { });
      return;
    }
    else {
      (await this.userService.addUser(this.adduser, this.defaultPermissionGroup.permissionGroupID)).subscribe(result => {

        this.dialogService.openSuccessModal(`Success`, `${result.message}`, () => { });
        this.goToPageOneParams('modify-user', result.data.userID);
      },
        error => {
          this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        });
    }
  }
}
