import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatronSitesDto } from 'src/app/model/Dtos/mdm-patron/patronSitesDto';
import { LeaderBoardPatronDto } from 'src/app/model/Dtos/profile-rewards-admin/leaderBoardPatronDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { LeaderBoardService } from 'src/app/service/profile-rewards-admin/leader-board.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-patron-leaderboard',
  templateUrl: './patron-leaderboard.component.html',
  styleUrls: ['./patron-leaderboard.component.css']
})
export class PatronLeaderboardComponent implements OnInit {

  @Input() tsogosunId: string;
  siteId: string;
  user: AuthToken;
  userSites: SiteDto[] = [];
  leaderBoardsPatronDto: LeaderBoardPatronDto[] = [];
  patronSites: PatronSitesDto[] = [];
  patronSite = {} as PatronSitesDto;
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";

  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private route: ActivatedRoute,
    public dialogService: DialogService,
    private patronService: PatronService,
    private leaderBoardService: LeaderBoardService) {

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

  async searchPatronLeaderBoard() {

    this.showNoResultsMessage = false;

    this.siteId = this.patronSite?.property_Registered.toString();

    if (!SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }

    this.leaderBoardsPatronDto = await this.leaderBoardService.getLeaderBoardByPatrons(this.siteId, this.patronSite.patronID.toString());

    if (this.leaderBoardsPatronDto?.length == 0) {
      this.showNoResultsMessage = true;
      this.resultsMessage = "No results found.";
    }
  }
}