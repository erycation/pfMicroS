import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatronScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/patronScratchCardDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-scratch-card',
  templateUrl: './patron-scratch-card.component.html',
  styleUrls: ['./patron-scratch-card.component.css']
})
export class PatronScratchCardComponent implements OnInit {

  user: AuthToken;
  userSites: SiteDto[] = [];
  siteId: number;
  patronScratchCardDto : PatronScratchCardDto[] = [];
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  patronNumber:  number;
  filterWinningStatus: string  = 'all';

  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private router: Router,
    public dialogService: DialogService,
    private scratchCardService : ScratchCardService) {

  }

   async ngOnInit() {

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.patronDetailsScratchCard);

    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.userSites.splice(userSiteIndex, 1);
    
    if(this.userSites[0] != null)
    {
      this.siteId = this.userSites[0].siteID;
    }
  }

  numberOnly(event): boolean {
    return SharedFunction.numberOnly(event);
  }

  async searchPatronScratchCards()
  {

    this.showNoResultsMessage = false;

    if(!SharedFunction.checkUndefinedObjectValue(this.siteId))
    {
      this.dialogService.openAlertModal("Alert","Please select Unit", ()=>{ });
      return;
    }

    if(!SharedFunction.checkUndefinedObjectValue(this.patronNumber))
    {
      this.dialogService.openAlertModal("Alert","Please enter patron number", ()=>{ });
      return;
    }

    this.patronScratchCardDto = await this.scratchCardService.getScratchCardsByPatronNumber(this.siteId.toString(), this.patronNumber.toString());

    if(this.patronScratchCardDto?.length == 0)
    {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
    }   
  }
}
