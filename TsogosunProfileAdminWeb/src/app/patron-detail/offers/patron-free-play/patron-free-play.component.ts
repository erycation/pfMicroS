import { Component, Input, OnInit } from '@angular/core';
import { PatronSitesDto } from 'src/app/model/Dtos/mdm-patron/patronSitesDto';
import { PatronFreePlayDto } from 'src/app/model/Dtos/profile-admin/patronFreePlayDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { RequestPatronFreePlay } from 'src/app/model/request/profile-admin/requestPatronFreePlay';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { OTPService } from 'src/app/service/profile-admin/otp-service';
import { ReportService } from 'src/app/service/profile-admin/report-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-free-play',
  templateUrl: './patron-free-play.component.html',
  styleUrls: ['./patron-free-play.component.css']
})
export class PatronFreePlayComponent implements OnInit {

  @Input() tsogosunId: string;
  user: AuthToken;
  startDate: Date;
  endDate: Date;
  bsValue = new Date; 
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  filterOfferStatus : string = "all";
  userSites: SiteDto[] = [];
  requestPatronFreePlay = {} as RequestPatronFreePlay;
  patronSites: PatronSitesDto[] = [];
  patronSiteFreePlay = {} as PatronSitesDto;
  patronFreePlayDto: PatronFreePlayDto[] = [];
  
  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private reportService: ReportService,
    private patronService: PatronService,
    public dialogService: DialogService,
    private otpService: OTPService) {

  }

  async ngOnInit() {

    this.startDate = new Date();
    this.endDate = new Date();
    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.offers);   

    (await this.patronService.getPatronActiveSitesByUserSites(this.tsogosunId, this.userSites)).subscribe(result => {
      this.patronSites = result;
      if(this.patronSites[0] != null)
      {
        this.patronSiteFreePlay = this.patronSites[0];
      }
    });
  }

  async searchFreePlay() {

    this.showNoResultsMessage = false;

    this.requestPatronFreePlay.siteId = this.patronSiteFreePlay?.property_Registered;
    this.requestPatronFreePlay.patronNo = this.patronSiteFreePlay.patronID;

    if (!SharedFunction.checkUndefinedObjectValue(this.requestPatronFreePlay.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit for Patron Freeplay", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please select start date", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please select end date", () => { });
      return;
    }
    else {

      this.requestPatronFreePlay.startDate = this.startDate.toISOString().slice(0,10);
      this.requestPatronFreePlay.endDate =  this.endDate.toISOString().slice(0,10);

      this.patronFreePlayDto = await this.reportService.getPatronFreePlays(this.requestPatronFreePlay);

      if (this.patronFreePlayDto?.length == 0) {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
      }
    }
  }

  canViewOTPNumber(otpnumber: any) : boolean
  {
    return SharedFunction.checkUndefinedObjectValue(otpnumber) ? true : false;
  }

  async openOTPNUmberModal(patronFreePlayDto: PatronFreePlayDto) {

    if(await this.otpService.canAuditUserViewOTPNumber(patronFreePlayDto.otpNumber) == true)
    {
      this.dialogService.openFreePlayrOtpModal(`OTP Number : ${patronFreePlayDto.otpNumber}`, patronFreePlayDto, () => { });
    }    
  }
}
