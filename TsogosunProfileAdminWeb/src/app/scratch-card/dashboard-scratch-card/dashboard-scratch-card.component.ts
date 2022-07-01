import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardDto';
import { ScratchCardOverViewDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardOverViewDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { RequestOverview } from 'src/app/model/request/profile-rewards-admin/requestOverview';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-dashboard-scratch-card',
  templateUrl: './dashboard-scratch-card.component.html',
  styleUrls: ['./dashboard-scratch-card.component.css']
})
export class DashboardScratchCardComponent implements OnInit {
  
  siteId: number;
  startDate: Date;
  endDate: Date;
  bsValue = new Date; 
  resultsMessage: string = "";
  showNoResultsMessage: Boolean = false;
  user: AuthToken;
  userSites: SiteDto[] = [];  
  scratchCards: ScratchCardDto[] = [];
  scratchCardOverViews: ScratchCardOverViewDto[] = [];
  requestOverview = {} as RequestOverview;
  scratchCardOverViewsItems: Array<any>;

  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private router: Router,
    public dialogService: DialogService,
    private scratchCardService: ScratchCardService) {

  }

  async ngOnInit() {

    var sixMonthFormTodayDate = new Date();
    sixMonthFormTodayDate.setMonth(sixMonthFormTodayDate.getMonth() - 6);
    this.startDate = sixMonthFormTodayDate;
    this.endDate = new Date();

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.scratchCardOverview);

    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.userSites.splice(userSiteIndex, 1);
    
    if(this.userSites[0] != null)
    {
      this.siteId = this.userSites[0].siteID;
      await this.displayOverviewData();
    }
  }

  async goToPage(pagename: string) {
    await this.router.navigate([pagename]);
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.scratchCardOverViewsItems = pageOfItems;
  }

  async displayOverviewData() {

    this.showNoResultsMessage = false;

    if (!SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    } 
    else if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please select start date", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please select end date", () => { });
      return;
    }
    else {

      const params: any = {
        startDate: this.startDate.toISOString().slice(0,10),
        endDate: this.endDate.toISOString().slice(0,10)
      };

      this.scratchCardOverViews = await this.scratchCardService.getScratchCardOverviewBySiteId(this.siteId.toString(), params);

      if (this.scratchCardOverViews?.length == 0) {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
      }
    }
  }
}
