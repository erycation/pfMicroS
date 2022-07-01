import { Component, Input, OnInit } from '@angular/core';
import { PatronSitesDto } from 'src/app/model/Dtos/mdm-patron/patronSitesDto';
import { PatronVoucherDto } from 'src/app/model/Dtos/profile-admin/patronVoucherDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { RequestPatronVoucher } from 'src/app/model/request/profile-admin/requestPatronVoucher';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { OTPService } from 'src/app/service/profile-admin/otp-service';
import { ReportService } from 'src/app/service/profile-admin/report-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-voucher',
  templateUrl: './patron-voucher.component.html',
  styleUrls: ['./patron-voucher.component.css']
})
export class PatronVoucherComponent implements OnInit {

  @Input() tsogosunId: string;
  user: AuthToken;
  startDate: Date;
  endDate: Date;
  bsValue = new Date; 
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  filterOfferStatus : string = "all";
  userSites: SiteDto[] = [];
  requestPatronVoucher = {} as RequestPatronVoucher;
  patronSites: PatronSitesDto[] = [];
  patronSiteVoucher = {} as PatronSitesDto;
  patronVouchersDto: PatronVoucherDto[] = [];

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
        this.patronSiteVoucher = this.patronSites[0];
      }
    });
  }

  canViewOTPNumber(otpnumber: any) : boolean
  {
    return SharedFunction.checkUndefinedObjectValue(otpnumber) ? true : false;
  }

  async searchVouchers() {

    this.showNoResultsMessage = false;

    this.requestPatronVoucher.siteId = this.patronSiteVoucher?.property_Registered;
    this.requestPatronVoucher.patronNo = this.patronSiteVoucher.patronID;

    if (!SharedFunction.checkUndefinedObjectValue(this.requestPatronVoucher.siteId)) {
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

      this.requestPatronVoucher.startDate = this.startDate.toISOString().slice(0,10);
      this.requestPatronVoucher.endDate =  this.endDate.toISOString().slice(0,10);

      this.patronVouchersDto = await this.reportService.getPatronVouchers(this.requestPatronVoucher);

      if (this.patronVouchersDto?.length == 0) {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
      }
    }
  }

  async openOTPNUmberModal(patronVoucherDto: PatronVoucherDto) {

    if(await this.otpService.canAuditUserViewOTPNumber(patronVoucherDto.otpNumber) == true)
    {
      this.dialogService.openVoucherOtpModal(`OTP Number : ${patronVoucherDto.otpNumber}`, patronVoucherDto, () => { });
    }    
  }
}
