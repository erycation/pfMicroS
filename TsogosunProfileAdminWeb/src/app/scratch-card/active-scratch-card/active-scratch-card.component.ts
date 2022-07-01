import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-active-scratch-card',
  templateUrl: './active-scratch-card.component.html',
  styleUrls: ['./active-scratch-card.component.css']
})
export class ActiveScratchCardComponent implements OnInit {

  user: AuthToken;
  userSites: SiteDto[] = [];
  editAddSites: SiteDto[] = [];
  siteId: number;
  scratchCardDto: ScratchCardDto[] = [];
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  scratchCardDtoItems: Array<any>;

  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private router: Router,
    public dialogService: DialogService,
    private scratchCardService: ScratchCardService) {

  }

  async ngOnInit() {

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.ScratchMaintanance);

    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.userSites.splice(userSiteIndex, 1);
    
    if (this.userSites[0] != null) {
      this.siteId = this.userSites[0].siteID;
    }
  }

  async searchActiveScratchCards() {

    this.showNoResultsMessage = false;

    if (!SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }

    this.scratchCardDto = await this.scratchCardService.getScratchCardsBySiteId(this.siteId.toString());

    if (this.scratchCardDto?.length == 0) {
      this.showNoResultsMessage = true;
      this.resultsMessage = "No results found.";
    }
  }

  canEditScracthCard(siteId : number) : Boolean 
  {
    this.editAddSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.addEditScratchCard);
    return this.sharedFunction.canEditItemBySite(this.editAddSites ,siteId)
  }

  goToLink(url: string) {
    window.open(url, "_blank");
  }

  async goToModifyScratchCard(scratchCard: ScratchCardDto) {
    await this.router.navigate(['modify-scratch-card', scratchCard.siteId, scratchCard.scratchCardUID]);
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.scratchCardDtoItems = pageOfItems;
  }
}
