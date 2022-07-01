import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatronSearchDto } from '../model/Dtos/mdm-patron/patronSearchDto';
import { RequestPatronParameter } from '../model/request/mdm-patron/requestPatronParameter';
import { AccountService } from '../service/account.service';
import { PatronService } from '../service/mdm-patron/patron.service';
import { DialogService } from '../shared/dialog/dialog.service';
import { ModalResetParams } from '../shared/modal-reset-params';
import { SectionUtility } from '../shared/section-utility';
import { SharedFunction } from '../shared/shared-function';
import { Pager } from '../util/pagination/pager';

@Component({
  selector: 'app-patron-list',
  templateUrl: './patron-list.component.html',
  styleUrls: ['./patron-list.component.css']
})
export class PatronListComponent extends ModalResetParams implements OnInit {

  requestPatronParameter = {} as RequestPatronParameter;
  patronSearchDto: PatronSearchDto[] = [];
  pager = new Pager();
  patronSearchDtoItems: Array<any>;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private patronService: PatronService,
    private dialogService: DialogService,) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.personalDetails);
  }

  async ngOnInit() {
  }

  numberOnly(event): boolean {
    return SharedFunction.numberOnly(event);
  }

  async searchPatron() {

    this.resetValidationFields();
    this.requestPatronParameter.siteID = 0;

    if((!SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.patronNumber)) &&
        (!SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.patronName)) &&
        (!SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.patronSurname)) &&
        (!SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.emailAddress)) &&
        (!SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.iDPassport)) &&
        (!SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.mobileNumber)) 
        )
    {
      this.dialogService.openAlertModal("Alert","Please search by Paton Number OR Name OR Surname OR Email OR ID/Passport OR Mobile Number", ()=>{ });

      return;
    }
    
    const params: any = {
      siteID: this.requestPatronParameter.siteID,
      patronNumber: SharedFunction.checkUndefinedObjectValue(this.requestPatronParameter.patronNumber) == true ? this.requestPatronParameter.patronNumber : 0,// this.requestPatronParameter.patronNumber == undefined ? 0 : this.requestPatronParameter.patronNumber,
      iDPassport: this.requestPatronParameter.iDPassport == undefined ? '' : this.requestPatronParameter.iDPassport,
      mobileNumber: this.requestPatronParameter.mobileNumber == undefined ? '' : this.requestPatronParameter.mobileNumber,
      patronName: this.requestPatronParameter.patronName == undefined ? '' : this.requestPatronParameter.patronName,
      patronSurname: this.requestPatronParameter.patronSurname == undefined ? '' : this.requestPatronParameter.patronSurname,
      emailAddress: this.requestPatronParameter.emailAddress == undefined ? '' : this.requestPatronParameter.emailAddress,
      sort: 'name,desc',
      ...this.pager.restParams()
    };

    this.patronSearchDto = await this.patronService.searchAllPatron(params);

    if(this.patronSearchDto?.length == 0)
    {
        this.displayNoResultsMessage();
    }    
  }

  async goToPatronDetail(patronItem: PatronSearchDto) {
    this.goToPageOneParams('patron-detail', patronItem.tsogosunid);
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.patronSearchDtoItems = pageOfItems;
  }
}

