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
  selector: 'app-patron-details-new-record',
  templateUrl: './patron-details-new-record.component.html',
  styleUrls: ['./patron-details-new-record.component.css']
})
export class PatronDetailsNewRecordComponent extends ModalResetParams implements OnInit {

  @Input() siteId: string;
  @Input() idNumber: string;
  @Input() mobileNumber: string;
  newRecordPatronDetailsDto: PatronDetailsDto[] = [];
  requestPatronDetails = {} as RequestPatronDetails;
  requestUpdatePatronStatus = {} as RequestUpdatePatronStatus;
  patronDetailsDto: PatronDetailsDto[] = [];
  patronDetailsDtoItems: Array<any>;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private dialogService: DialogService,
    private mspatronDetailsService: MSPatronDetailsService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }

  async ngOnInit() {

    if(SharedFunction.checkUndefinedObjectValue(this.siteId))
    {
      this.patronDetailsDto = await this.mspatronDetailsService.getPatronDetailsBySiteID(this.requestPatronDetails);
      this.newRecordPatronDetailsDto = this.patronDetailsDto.filter(x => x.recordStatus == 'New Record');
      if (this.newRecordPatronDetailsDto?.length == 0) {
        this.displayNoResultsMessage();
      }
    }
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
  
  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.patronDetailsDtoItems = pageOfItems;
  }
}
