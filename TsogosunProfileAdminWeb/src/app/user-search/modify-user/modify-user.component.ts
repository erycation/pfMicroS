import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserApplicationSectionDto } from 'src/app/model/Dtos/profile-admin/userApplicationSectionDto';
import { UserDto } from 'src/app/model/Dtos/profile-admin/userDto';
import { ApplicationDto } from 'src/app/model/loginDto/applicationDto';
import { SectionDto } from 'src/app/model/loginDto/sectionDto';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { UserPermission } from 'src/app/model/profile-admin/userPermission';
import { AccountService } from 'src/app/service/account.service';
import { UserPermissionService } from 'src/app/service/profile-admin/user-permission.service';
import { UserService } from 'src/app/service/profile-admin/user-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-modify-user',
  templateUrl: './modify-user.component.html',
  styleUrls: ['./modify-user.component.css']
})
export class ModifyUserComponent extends ModalResetParams implements OnInit {

  site = {} as SiteDto;
  edituser = {} as UserDto;
  section = {} as SectionDto;
  application = {} as ApplicationDto;
  userPermission = {} as UserPermission;
  userApplicationSectionDto = {} as UserApplicationSectionDto;
  sectionSites: SiteDto[] = [];
  sections: SectionDto[] = [];

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private userService: UserService,
    private userPermissionService: UserPermissionService,
    private route: ActivatedRoute,
    private dialogService: DialogService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.UserMaintanance)

  }

  async ngOnInit() {
    this.edituser = await this.userService.getUserByUserUd(this.route.snapshot.params.userId);
    this.userApplicationSectionDto = null;
    this.userApplicationSectionDto = await this.userService.getUserApplicationSectionByUserId(this.route.snapshot.params.userId);
  }

  async changeStatus() {
    this.edituser.status = this.edituser.isActive == true ? 'Active' : 'Not Active';
  }

  async updateUserDetails() {
    if (!SharedFunction.checkUndefinedObjectValue(this.edituser.firstname)) {
      this.dialogService.openAlertModal("Alert", "Firstname Required", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.edituser.surname)) {
      this.dialogService.openAlertModal("Alert", "Surname Required", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.edituser.isActive)) {
      this.dialogService.openAlertModal("Alert", "Please Select Status", () => { });
      return;
    }
    else {
      (await this.userService.updateUser(this.edituser)).subscribe(result => {

        this.dialogService.openSuccessModal(`Success`, `${result.message}`, () => { });
      },
        error => {
          this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
          return;
        });

      this.userApplicationSectionDto = await this.userService.getUserApplicationSectionByUserId(this.route.snapshot.params.userId);
    }
  }

  async populateSectionByApplication() {
    this.site = null;
    this.sectionSites = [];
    this.section = null;
    this.sections = [];
    this.sections = this.application?.sections;
  }

  async populateUnitBySection() {
    this.site = null;
    this.sectionSites = [];
    this.sectionSites = this.section?.sites;

    if (this.sectionSites[0] != null) {
      this.site = this.sectionSites[0];
    }
  }

  async addUserPermission() {
    if (!SharedFunction.checkUndefinedObjectValue(this.application)) {
      this.dialogService.openAlertModal("Alert", "Please Select Application", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.section)) {
      this.dialogService.openAlertModal("Alert", "Please Select Section", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.site)) {
      this.dialogService.openAlertModal("Alert", "Please Select Unit", () => { });
      return;
    }
    else {
      this.userPermission.userID = Number(this.route.snapshot.params.userId);
      this.userPermission.applicationID = this.application.applicationId;
      this.userPermission.applicationSectionID = this.section.sectionId;
      this.userPermission.siteID = this.site.siteID;

      await this.userPermissionService.addUserPermissionGroup(this.userPermission);
      this.dialogService.openSuccessModal(`Success`, `User is successfully added`, () => {
        this.clearAddSectionFields();
      });

      this.userApplicationSectionDto = null;
      this.userApplicationSectionDto = await this.userService.getUserApplicationSectionByUserId(this.route.snapshot.params.userId);
    }
  }

  async unlinkSectionToUnit(application: any, section: any, site: any) {
    this.userPermission.userID = Number(this.route.snapshot.params.userId);
    this.userPermission.applicationID = application.applicationId;
    this.userPermission.applicationSectionID = section.sectionId;
    this.userPermission.siteID = site.siteID;

    this.dialogService.openConfirmModal(`Confirm`, `Are you sure you remove section from unit?`, async () => {
      await this.userPermissionService.deactivateUserPermissionGroup(this.userPermission);
      this.dialogService.openSuccessModal(`Success`, `Section is successfully deactivated`, () => { });
      this.userApplicationSectionDto = null;
      this.userApplicationSectionDto = await this.userService.getUserApplicationSectionByUserId(this.route.snapshot.params.userId);
    });
  }

  clearAddSectionFields() {
    this.application = null;
    this.section = null;
    this.sections = [];
    if (this.userSites[0] != null) {
      this.site = this.userSites[0];
    }

    this.sections = this.application?.sections;
    this.site = null;
    this.sectionSites = [];
  }
}
