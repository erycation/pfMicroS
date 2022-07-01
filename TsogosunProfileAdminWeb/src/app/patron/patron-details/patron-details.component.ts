import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatronDetailsDto } from 'src/app/model/Dtos/ms-patron-details/patronDetailsDto';
import { RequestPatronDetails } from 'src/app/model/request/ms-patron-details/requestPatronDetails';
import { RequestUpdatePatronStatus } from 'src/app/model/request/ms-patron-details/requestUpdatePatronStatus';
import { AccountService } from 'src/app/service/account.service';
import { MSPatronDetailsService } from 'src/app/service/ms-patron-details/ms-patron-details.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-details',
  templateUrl: './patron-details.component.html',
  styleUrls: ['./patron-details.component.css']
})
export class PatronDetailsComponent extends ModalResetParams implements OnInit {

  requestPatronDetails = {} as RequestPatronDetails;
  requestUpdatePatronStatus = {} as RequestUpdatePatronStatus;
  patronDetailsDto: PatronDetailsDto[] = [];
  newRecordPatronDetailsDto: PatronDetailsDto[] = [];
  placedOnHoldPatronDetailsDto: PatronDetailsDto[] = [];
  patronDetailsDtoItems: Array<any>;
  siteId: string;
  idNumber: string;
  mobileNumber: string;
  active:any = 1;
  
  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private mspatronDetailsService: MSPatronDetailsService,
    private dialogService: DialogService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }

  async ngOnInit() { 
  }

  async getPatronDetailsBySiteId() {

    this.resetValidationFields();
    this.siteId = this.requestPatronDetails.siteId.toString();
    this.idNumber = this.requestPatronDetails.idpassport;
    this.mobileNumber = this.requestPatronDetails.mobileNumber;

    this.patronDetailsDto = await this.mspatronDetailsService.getPatronDetailsBySiteID(this.requestPatronDetails);
    this.newRecordPatronDetailsDto = this.patronDetailsDto.filter(x => x.recordStatus == 'New Record');
    if (this.newRecordPatronDetailsDto?.length == 0) {
      this.displayNoResultsMessage();
    }

    this.placedOnHoldPatronDetailsDto = this.patronDetailsDto.filter(x => x.recordStatus == 'In Progress');
    if (this.placedOnHoldPatronDetailsDto?.length == 0) {
      this.displayPlaceOnHoldNoResultsMessage();
    }
    this.active = 1;
  }

  canAccessInprogressRecord(allocatedUser: String): boolean {
    return !SharedFunction.checkUndefinedObjectValue(allocatedUser) ? false : this.user.username.toLocaleLowerCase() == allocatedUser.toLocaleLowerCase() ? true : false;
  }

  canAccessApprovedRecord(approvedUser: String): boolean {
    return !SharedFunction.checkUndefinedObjectValue(approvedUser) ? false : this.user.username.toLocaleLowerCase() == approvedUser.toLocaleLowerCase() ? true : false;
  }

  async searchPatronDetails() {
    if (!SharedFunction.checkUndefinedObjectValue(this.requestPatronDetails.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }
    await this.getPatronDetailsBySiteId();
  }

  async goToUpdatePatronDetail(patronDetailsDto: PatronDetailsDto) {

    this.requestUpdatePatronStatus.userDetailID = patronDetailsDto.userId;
    this.requestUpdatePatronStatus.status = `In Progress`;
    this.requestUpdatePatronStatus.userName = this.user.username;

    (await this.mspatronDetailsService.updatePatronStatus(this.requestUpdatePatronStatus)).subscribe(result => {
      if (this.igtSites.includes(patronDetailsDto.siteId)) {//IGT 
        //this.goToPageTwoParams('update-patron-details', patronDetailsDto.siteId, patronDetailsDto.userId);
        this.goToPageTwoParams('update-patron-details-igt', patronDetailsDto.siteId, patronDetailsDto.userId);        
      }
      else {//gamesmart
        this.goToPageTwoParams('update-patron-details-gamesmart', patronDetailsDto.siteId, patronDetailsDto.userId);
      }
    },
      error => {
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
      });
  }

  isRecordSubmittedToGaming(recordStatus: string) {
    return recordStatus.toLocaleLowerCase() == 'approved' ? false : true;
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.patronDetailsDtoItems = pageOfItems;
  }
}
