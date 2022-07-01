import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GamingAreaDto } from 'src/app/model/Dtos/profile-rewards-admin/gamingAreaDto';
import { LeaderBoardPromotionDto } from 'src/app/model/Dtos/profile-rewards-admin/leaderBoardPromotionDto';
import { MobileSettingDto } from 'src/app/model/Dtos/profile-rewards-admin/mobileSettingDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { RequestAddUpdateLeaderBoard } from 'src/app/model/request/profile-rewards-admin/requestAddUpdateLeaderBoard';
import { AccountService } from 'src/app/service/account.service';
import { GamingAreasService } from 'src/app/service/profile-rewards-admin/gaming-areas.service';
import { LeaderBoardService } from 'src/app/service/profile-rewards-admin/leader-board.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { LeaderboardStrapiImagesComponent } from '../leaderboard-strapi-images/leaderboard-strapi-images.component';

@Component({
  selector: 'app-update-leaderboard',
  templateUrl: './update-leaderboard.component.html',
  styleUrls: ['./update-leaderboard.component.css']
})
export class UpdateLeaderboardComponent extends ModalResetParams implements OnInit {

  startDate: Date;
  startTime = new Date();
  endDate: Date;
  endTime = new Date();
  bsValue = new Date;
  siteFullName: string;
  mobileSettingDto = {} as MobileSettingDto;
  requestAddUpdateLeaderBoard = {} as RequestAddUpdateLeaderBoard;
  leaderBoardPromotionDto = {} as LeaderBoardPromotionDto;
  gamingAreas: GamingAreaDto[] = [];
  leaderBoardGamingAreas: GamingAreaDto[] = [];
 
  constructor(accountService: AccountService,
              sharedFunction: SharedFunction,
              router: Router,
              private route: ActivatedRoute,
              public datepipe: DatePipe,
              public dialogService: DialogService,
              private leaderBoardService: LeaderBoardService,
              private gamingAreasService: GamingAreasService
            ) {
              super(accountService,
                sharedFunction,
                router,
                SectionUtility.leaderBoardAdmin);
            }


  async ngOnInit() {

    this.siteFullName = this.userSites.find(s => s.siteID == Number(this.route.snapshot.params.siteId)).siteFullName;
    this.gamingAreas = await this.gamingAreasService.getAllGamingAreasBySiteId(this.route.snapshot.params.siteId);
    this.leaderBoardPromotionDto = await this.leaderBoardService.getLeaderBoardByPromotion(this.route.snapshot.params.siteId, this.route.snapshot.params.promotionId);

    this.startDate = new Date(this.leaderBoardPromotionDto.startDate);
    this.startTime = this.leaderBoardPromotionDto.startDate;
    this.endDate = new Date(this.leaderBoardPromotionDto.endDate);
    this.endTime = this.leaderBoardPromotionDto.endDate;

    this.leaderBoardGamingAreas = this.leaderBoardPromotionDto.gamingAreaDtos;

    this.leaderBoardGamingAreas.forEach(async element => {
      await this.removeSavedGamingArreas(element);
    });

    this.mobileSettingDto.mainHeading = this.leaderBoardPromotionDto?.mobileSettingDto?.mainHeading;
    this.mobileSettingDto.mainImage = this.leaderBoardPromotionDto?.mobileSettingDto?.mainImage;
  }

  async changeStatus() {
    this.leaderBoardPromotionDto.status = this.leaderBoardPromotionDto.active == true ? 'Active' : 'Not Active';
  }

  async updateMobileMainImage(imageTitle: string) {
    imageTitle = `${this.siteFullName} - ${imageTitle}`;
    this.mobileSettingDto.mainImage = await this.dialogService.openReturnModalService(LeaderboardStrapiImagesComponent, imageTitle, this.route.snapshot.params.siteId, () => { });
  }

  goToLink(url: string) {
    window.open(url, "_blank");
  }

  numberOnly(event): boolean {
    return SharedFunction.numberOnly(event);
  }

  async addGamingArreas(gamingArea: GamingAreaDto) {
    const index = this.gamingAreas.findIndex(user => user.location === gamingArea.location);
    this.gamingAreas.splice(index, 1);
    this.leaderBoardGamingAreas.push(gamingArea);
  }

  async addAllGamingArreas() {

    this.gamingAreas.forEach(gamingAreaElement => {
      var gamingLocation = this.leaderBoardGamingAreas.find(gaming => gaming.location === gamingAreaElement.location)?.location;
      if (!SharedFunction.checkUndefinedObjectValue(gamingLocation)) {
        this.leaderBoardGamingAreas.push(gamingAreaElement);
      }
    })

    this.gamingAreas = [];
  }

  async removeAllGamingArreas() {

    this.leaderBoardGamingAreas.forEach(gamingAreaElement => {
      var gamingLocation = this.gamingAreas.find(gaming => gaming.location === gamingAreaElement.location)?.location;
      if (!SharedFunction.checkUndefinedObjectValue(gamingLocation)) {
        this.gamingAreas.push(gamingAreaElement);
      }
    })

    this.leaderBoardGamingAreas = [];
  }

  async removeGamingArreas(gamingArea: GamingAreaDto) {
    const index = this.leaderBoardGamingAreas.findIndex(user => user.location === gamingArea.location);
    this.leaderBoardGamingAreas.splice(index, 1);
    this.gamingAreas.push(gamingArea);
  }

  async removeSavedGamingArreas(gamingArea: GamingAreaDto) {
    const index = this.gamingAreas.findIndex(user => user.location === gamingArea.location);
    this.gamingAreas.splice(index, 1);
  }

  async updateLeaderBoard() {

    this.leaderBoardPromotionDto.gamingAreaDtos = this.leaderBoardGamingAreas;

    if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select Unit", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.promotionName)) {
      this.dialogService.openAlertModal("Alert", "Please enter leader board name", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.promotionType)) {
      this.dialogService.openAlertModal("Alert", "Please select points type", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter start date", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.startTime)) {
      this.dialogService.openAlertModal("Alert", "Please enter start date time", () => { });
      return;
    }

    else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter end date", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.endTime)) {
      this.dialogService.openAlertModal("Alert", "Please enter end date time", () => { });
      return;
    }

    else if (new Date(this.startDate).valueOf() > new Date(this.endDate).valueOf()) {
      this.dialogService.openAlertModal("Alert", "Start date cannot be greater that end date", () => { });
      return;
    }

    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.startRank)) {
      this.dialogService.openAlertModal("Alert", "Please select start rank", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.endRank)) {
      this.dialogService.openAlertModal("Alert", "Please select end rank", () => { });
      return;
    }
    else if (Number(this.leaderBoardPromotionDto.startRank) > Number(this.leaderBoardPromotionDto.endRank)) {
      this.dialogService.openAlertModal("Alert", "Start rank cannot be greater than end rank", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.noPatrons)) {
      this.dialogService.openAlertModal("Alert", "Please enter number of patrons", () => { });
      return;
    }
    else if (Number(this.leaderBoardPromotionDto.noPatrons) < 1) {
      this.dialogService.openAlertModal("Alert", " Number of patrons must be greater than zero", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.minPoints)) {
      this.dialogService.openAlertModal("Alert", "Please enter minimum points", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.maxPoints)) {
      this.dialogService.openAlertModal("Alert", "Please enter maximum points", () => { });
      return;
    }
    else if (Number(this.leaderBoardPromotionDto.minPoints) > Number(this.leaderBoardPromotionDto.maxPoints)) {
      this.dialogService.openAlertModal("Alert", "Minimum points cannot be greater than maximum points", () => { });
      return;
    }

    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.gamingAreaDtos)) {
      this.dialogService.openAlertModal("Alert", "Please select one or more gaming areas", () => { });
      return;
    }
    else if (this.leaderBoardPromotionDto.gamingAreaDtos.length < 1) {
      this.dialogService.openAlertModal("Alert", "Please select one or more gaming areas", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.leaderBoardPromotionDto.active)) {
      this.dialogService.openAlertModal("Alert", "Please select status", () => { });
      return;
    }
    else if (this.leaderBoardPromotionDto.displayOnMobile) {
      if (!SharedFunction.checkUndefinedObjectValue(this.mobileSettingDto.mainHeading)) {
        this.dialogService.openAlertModal("Alert", "Please enter mobile heading", () => { });
        return;
      }
      else if (!SharedFunction.checkUndefinedObjectValue(this.mobileSettingDto.mainImage)) {
        this.dialogService.openAlertModal("Alert", "Please enter mobile main image", () => { });
        return;
      }
      else {
        this.leaderBoardPromotionDto.mobileSettingDto = this.mobileSettingDto;
      }
    }

    this.requestAddUpdateLeaderBoard.startTime = this.datepipe.transform(this.startTime, 'yyyy/MM/dd hh:mm:ss a');
    this.requestAddUpdateLeaderBoard.endTime = this.datepipe.transform(this.endTime, 'yyyy/MM/dd hh:mm:ss a');
    this.leaderBoardPromotionDto.startDate = this.startDate.toISOString().slice(0, 10);
    this.leaderBoardPromotionDto.endDate = this.endDate.toISOString().slice(0, 10);

    this.requestAddUpdateLeaderBoard.leaderBoardPromotionDto = this.leaderBoardPromotionDto;

    (await this.leaderBoardService.updateLeaderBoardPromotion(this.requestAddUpdateLeaderBoard)).subscribe(result => {
      this.dialogService.openSuccessModal("Success", result.message, () => { });
    },
      error => {
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
      });
  }
}


