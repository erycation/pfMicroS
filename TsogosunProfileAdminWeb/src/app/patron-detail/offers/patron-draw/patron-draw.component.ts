import { Component, Input, OnInit } from '@angular/core';
import { PatronSitesDto } from 'src/app/model/Dtos/mdm-patron/patronSitesDto';
import { PatronDrawDto } from 'src/app/model/Dtos/profile-admin/patronDrawDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { RequestPatronDraw } from 'src/app/model/request/profile-admin/requestPatronDraw';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { ReportService } from 'src/app/service/profile-admin/report-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-draw',
  templateUrl: './patron-draw.component.html',
  styleUrls: ['./patron-draw.component.css']
})
export class PatronDrawComponent implements OnInit {

  @Input() tsogosunId: string;
  startDate: Date;
  endDate: Date;
  bsValue = new Date; 
  resultsMessage: string = "";
  filterPromotionStatus : string = "all";
  showNoResultsMessage: Boolean = false;
  user: AuthToken;
  userSites: SiteDto[] = [];
  requestPatronDraw = {} as RequestPatronDraw;
  patronSites: PatronSitesDto[] = [];
  patronSiteDraws = {} as PatronSitesDto;
  patronDrawDto: PatronDrawDto[] = [];
  
  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private reportService: ReportService,
    private patronService: PatronService,
    public dialogService: DialogService) {

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
        this.patronSiteDraws = this.patronSites[0];
      }
    });
  }

  async searchDraw() {

    this.showNoResultsMessage = false;

    this.requestPatronDraw.siteId = this.patronSiteDraws?.property_Registered;
    this.requestPatronDraw.patronNo = this.patronSiteDraws.patronID;

    if (!SharedFunction.checkUndefinedObjectValue(this.requestPatronDraw.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit for Patron Draw", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please select start date", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please select end date", () => { });
      return;
    }
    else {

      this.requestPatronDraw.startDate = this.startDate.toISOString().slice(0,10);
      this.requestPatronDraw.endDate =  this.endDate.toISOString().slice(0,10);
      this.patronDrawDto = await this.reportService.getPatronDraws(this.requestPatronDraw);

      if (this.patronDrawDto?.length == 0) {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
      }
    }
  }
}
