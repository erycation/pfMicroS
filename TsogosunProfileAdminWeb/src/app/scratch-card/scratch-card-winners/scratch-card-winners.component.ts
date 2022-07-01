import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardDto';
import { ScratchCardOverViewDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardOverViewDto';
import { ScratchCardPrizeDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardPrizeDto';
import { ScratchCardWinnersDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardWinnersDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardPrizeService } from 'src/app/service/profile-rewards-admin/scratch-card-prize.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-scratch-card-winners',
  templateUrl: './scratch-card-winners.component.html',
  styleUrls: ['./scratch-card-winners.component.css']
})
export class ScratchCardWinnersComponent implements OnInit {

  siteId: number;
  scratchCardUID: string;
  startDate: Date;
  endDate: Date;
  bsValue = new Date; 
  resultsMessage: string = "";
  filterByPatronNo: string = "";
  user: AuthToken;
  userSites: SiteDto[] = [];
  scratchCardForWinners: ScratchCardDto[] = [];
  scratchCardWinnersDto: ScratchCardWinnersDto[] = [];
  scratchCardPrizesDto: ScratchCardPrizeDto[] = [];
  scratchCardPrizeDto = {} as ScratchCardPrizeDto;
  showNoResultsMessage: Boolean = false;
  showPdfExcelReport: Boolean = false;
  scratchCardForWinnersItems: Array<any>;

  constructor(private accountService: AccountService,
    private sharedFunction: SharedFunction,
    private route: ActivatedRoute,
    private router: Router,
    public dialogService: DialogService,
    private scratchCardService: ScratchCardService,
    private scratchCardPrizeService: ScratchCardPrizeService) {

  }

  async ngOnInit() {

    var sixMonthFormTodayDate = new Date();
    sixMonthFormTodayDate.setMonth(sixMonthFormTodayDate.getMonth() - 6);
    this.startDate = sixMonthFormTodayDate;
    this.endDate = new Date();

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.scratchCardWinners);

    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.userSites.splice(userSiteIndex, 1);

  }

  async populateScratchCardsForWinner() {

    this.scratchCardUID = null;
    this.scratchCardForWinners = [];
    this.scratchCardPrizesDto = [];
    this.scratchCardPrizeDto = null;

    const params: any = {
      startDate: this.startDate.toISOString().split('T')[0],
      endDate: this.endDate.toISOString().split('T')[0]
    };

    this.scratchCardForWinners = await this.scratchCardService.getScratchCardForWinners(this.siteId.toString(), params);

  }

  async populatePrizeTypesByScratchCard()
  {

    this.scratchCardPrizeDto = null;
    this.scratchCardPrizesDto = [];
    this.scratchCardPrizesDto = await this.scratchCardPrizeService.getScratchCardPrizeByScratchCardId(this.scratchCardUID, this.siteId.toString());
  
  }

  async resetScratchCardByUnit()
  {
    if (SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      await this.populateScratchCardsForWinner();
    }    
  }

  async searchWinners() {

    this.showNoResultsMessage = false;
    this.showPdfExcelReport = false;    

    if (!SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please Select Unit", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardUID)) {
      this.dialogService.openAlertModal("Alert", "Please Select Scratch Card", () => { });
      return;
    }
    else {

      const params: any = {
        site: this.siteId.toString(),
        promotionUID: this.scratchCardUID,
        prizeType: this.scratchCardPrizeDto.prizeTypeID,
        message: this.scratchCardPrizeDto.winningMessage,
      };

      this.scratchCardWinnersDto = await this.scratchCardService.getScratchCardWinners(params);
      
      if (this.scratchCardWinnersDto?.length == 0) {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
      }else
      {
        this.showPdfExcelReport = true;
      }
    }
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.scratchCardForWinnersItems = pageOfItems;
  }

  async generatePDFOrExcelReportWinners(reportType:string)
  {
    const params: any = {
      site: this.siteId.toString(),
      promotionUID: this.scratchCardUID,
      prizeType: this.scratchCardPrizeDto.prizeTypeID,
      message: this.scratchCardPrizeDto.winningMessage,
    };

    if(reportType == 'pdf')
    {
      return await this.scratchCardService.downloadPDFReportWinners(params);
    }
     return await this.scratchCardService.downloadExcelReportWinners(params);
  }

}
