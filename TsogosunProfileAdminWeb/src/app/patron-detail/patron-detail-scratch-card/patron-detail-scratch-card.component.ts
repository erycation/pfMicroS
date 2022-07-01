import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatronSitesDto } from 'src/app/model/Dtos/mdm-patron/patronSitesDto';
import { PatronScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/patronScratchCardDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-detail-scratch-card',
  templateUrl: './patron-detail-scratch-card.component.html',
  styleUrls: ['./patron-detail-scratch-card.component.css']
})
export class PatronDetailScratchCardComponent implements OnInit {

  @Input() tsogosunId: string;
  siteId: string;
  user: AuthToken;
  userSites: SiteDto[] = [];
  patronScratchCardDto : PatronScratchCardDto[] = [];
  patronSites: PatronSitesDto[] = [];
  patronSite = {} as PatronSitesDto;
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";

  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private route: ActivatedRoute,
    public dialogService: DialogService,
    private patronService: PatronService,
    private scratchCardService : ScratchCardService
    ) {

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.patronLeaderBoard);

  }

  async ngOnInit() {

    (await this.patronService.getPatronActiveSitesByUserSites(this.tsogosunId, this.userSites)).subscribe(result => {

      this.patronSites = result;
      if(this.patronSites[0] != null)
      {
        this.patronSite = this.patronSites[0];
      }
    });
  }

  async searchPatronScratchCard()
  {
    this.showNoResultsMessage = false;

    this.siteId = this.patronSite?.property_Registered.toString();

    if (!SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }

    this.patronScratchCardDto = await this.scratchCardService.getScratchCardsByPatronNumber(this.siteId.toString(), this.patronSite.patronID.toString());

    if(this.patronScratchCardDto?.length == 0)
    {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
    } 
  }

}
