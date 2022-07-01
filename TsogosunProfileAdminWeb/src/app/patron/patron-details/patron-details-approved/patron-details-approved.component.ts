import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApprovedUserDetailsDto } from 'src/app/model/Dtos/ms-patron-details/approvedUserDetailsDto';
import { AccountService } from 'src/app/service/account.service';
import { MSPatronDetailsService } from 'src/app/service/ms-patron-details/ms-patron-details.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-details-approved',
  templateUrl: './patron-details-approved.component.html',
  styleUrls: ['./patron-details-approved.component.css']
})
export class PatronDetailsApprovedComponent extends ModalResetParams implements OnInit {

  @Input() siteId: string;
  approvedUserDetailsDto: ApprovedUserDetailsDto[] = [];

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private mspatronDetailsService: MSPatronDetailsService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }

  async ngOnInit() {
    if(SharedFunction.checkUndefinedObjectValue(this.siteId))
    {
      this.approvedUserDetailsDto = await this.mspatronDetailsService.getApprovedPatroRegistrationBySiteID(this.siteId);
    }
  }

  canAccessApprovedRecord(approvedUser: String): boolean {
    return !SharedFunction.checkUndefinedObjectValue(approvedUser) ? false : this.user.username.toLocaleLowerCase() == approvedUser.toLocaleLowerCase() ? true : false;
  }

  isRecordSubmittedToGaming(recordStatus: string) {
    return recordStatus.toLocaleLowerCase() == 'approved' ? false : true;
  }
  
  async goToApprovedSubmitToIGT(approvedUserDetailsDto: ApprovedUserDetailsDto) {
    if (this.igtSites.includes(approvedUserDetailsDto.siteId)) {//IGT 
      this.goToPageTwoParams('approved-submit-igt', approvedUserDetailsDto.siteId, approvedUserDetailsDto.userId)
      }else{//gamesmart
        this.goToPageTwoParams('approved-submit-gamesmart', approvedUserDetailsDto.siteId, approvedUserDetailsDto.userId)
      }    
  }

}
