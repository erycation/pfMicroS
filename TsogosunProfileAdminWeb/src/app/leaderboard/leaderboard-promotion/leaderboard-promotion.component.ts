import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LeaderBoardPromotionDto } from 'src/app/model/Dtos/profile-rewards-admin/leaderBoardPromotionDto';
import { AccountService } from 'src/app/service/account.service';
import { LeaderBoardService } from 'src/app/service/profile-rewards-admin/leader-board.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-leaderboard-promotion',
  templateUrl: './leaderboard-promotion.component.html',
  styleUrls: ['./leaderboard-promotion.component.css']
})
export class LeaderboardPromotionComponent extends ModalResetParams implements OnInit {

  startDate: Date;
  endDate: Date;
  bsValue = new Date;
  siteId: number;
  leaderBoardPromotionDto: LeaderBoardPromotionDto[] = [];
  leaderBoardPromotionDtoItems: Array<any>;
  filterByPatronNo: string = "";

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private dialogService: DialogService,
    private leaderBoardService: LeaderBoardService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.leaderBoardAdmin);

  }

  async ngOnInit() {

    var sixMonthFormTodayDate = new Date();
    sixMonthFormTodayDate.setMonth(sixMonthFormTodayDate.getMonth() - 6);
    this.startDate = sixMonthFormTodayDate;
    this.endDate = new Date();

    if (this.userSites[0] != null) {
      this.siteId = this.userSites[0].siteID;
    }
  }

  async searchActiveScratchCards() {

    this.resetValidationFields();

    if (!SharedFunction.checkUndefinedObjectValue(this.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }
    if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please select start date", () => { });
      return;
    }
    if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please select end date", () => { });
      return;
    }

    const params: any = {
      startDate: this.startDate.toISOString().split('T')[0],
      endDate: this.endDate.toISOString().split('T')[0]
    };

    this.leaderBoardPromotionDto = await this.leaderBoardService.getLeaderBoardPromotionsBySiteId(this.siteId.toString(), params);

    if (this.leaderBoardPromotionDto?.length == 0) {
      this.displayNoResultsMessage();
    }
  }

  goToLink(url: string) {
    window.open(url, "_blank");
  }

  goToModifyLeaderBoard(leaderBoardPromotion: LeaderBoardPromotionDto) {
    if (leaderBoardPromotion.isGroupLeaderBoard) {
      this.goToPageTwoParams('modify-group-leaderboard', leaderBoardPromotion.siteId, leaderBoardPromotion.promotionID);
    }
    else {
      this.goToPageTwoParams('modify-leaderboard', leaderBoardPromotion.siteId, leaderBoardPromotion.promotionID);
    }
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.leaderBoardPromotionDtoItems = pageOfItems;
  }
}

