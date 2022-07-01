import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScratchCardMessageDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardMessageDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardMessageService } from 'src/app/service/profile-rewards-admin/scratch-card-message.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-message-settings',
  templateUrl: './message-settings.component.html',
  styleUrls: ['./message-settings.component.css']
})
export class MessageSettingsComponent implements OnInit {

  user: AuthToken;
  userSites: SiteDto[] = [];
  site: SiteDto;
  scratchCardMessageDto : ScratchCardMessageDto[] = [];
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  scratchCardMessageDtoItems: Array<any>;
   
  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private router: Router,
    public dialogService: DialogService,
    private scratchCardMessageService : ScratchCardMessageService) {

  }


  async ngOnInit() {

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.ScratchMaintanance);
    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.userSites.splice(userSiteIndex, 1);
    if(this.userSites[0] != null)
    {
      this.site = this.userSites[0];
    }
  }

  async searchMessage()
  {
    this.scratchCardMessageDto = await this.scratchCardMessageService.getActiveScratchCardsMessage(this.site.siteID.toString());
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.scratchCardMessageDtoItems = pageOfItems;
  }
}
