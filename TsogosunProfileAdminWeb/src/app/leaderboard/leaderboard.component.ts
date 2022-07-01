import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../service/account.service';
import { ModalResetParams } from '../shared/modal-reset-params';
import { SectionUtility } from '../shared/section-utility';
import { SharedFunction } from '../shared/shared-function';

@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent extends ModalResetParams implements OnInit {

  siteId: number;
  canAddLeaderboardGroup: boolean = false;
  canAddLeaderboardLocal: boolean = false;

  constructor(accountService: AccountService,
              sharedFunction: SharedFunction,
              router: Router) { 
                super(accountService,
                      sharedFunction,
                      router,
                      SectionUtility.leaderBoardAdmin);  
              }

  async ngOnInit() {
    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.canAddLeaderboardGroup = userSiteIndex == -1 ? false : true; 
    this.canAddLeaderboardLocal = this.userSites.splice(userSiteIndex, 1).length > 0 ? true : false;
  }
}
