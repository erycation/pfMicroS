import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardDto';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { TileImagesComponent } from '../scratch-card-strapi-images/tile-images/tile-images.component';

@Component({
  selector: 'app-add-scratch-card',
  templateUrl: './add-scratch-card.component.html',
  styleUrls: ['./add-scratch-card.component.css']
})
export class AddScratchCardComponent extends ModalResetParams implements OnInit {

  siteDto = {} as SiteDto;
  scratchCardDto = {} as ScratchCardDto;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private scratchCardService: ScratchCardService,
    private route: ActivatedRoute,
    private dialogService: DialogService,) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.addEditScratchCard);
  }

  async ngOnInit() {
    const userSiteIndex = this.userSites.findIndex(userSite => userSite.siteID === 0);
    this.userSites.splice(userSiteIndex, 1);

    if (this.userSites[0] != null) {
      this.siteDto = this.userSites[0];
    }
  }

  async clearAndpopulateStrapiContentPerUnit() {
    this.scratchCardDto.scratchCardImage = '';
    this.scratchCardDto.tileImagePath = '';
  }

  async addScratchCardImage(imageTitle: string) {

    if (!SharedFunction.checkUndefinedObjectValue(this.siteDto)) {
      this.dialogService.openAlertModal("Alert", "Please select unit", () => { });
      return;
    }
    imageTitle = `${this.siteDto.siteFullName} - ${imageTitle}`;
    this.scratchCardDto.scratchCardImage = await this.dialogService.openReturnModalService(TileImagesComponent, imageTitle, this.siteDto.siteID, () => { });
  }

  async addScratchCardTileImage(imageTitle: string) {

    if (!SharedFunction.checkUndefinedObjectValue(this.siteDto)) {
      this.dialogService.openAlertModal("Alert", "Please select unit", () => { });
      return;
    }
    imageTitle = `${this.siteDto.siteFullName} - ${imageTitle}`;
    this.scratchCardDto.tileImagePath = await this.dialogService.openReturnModalService(TileImagesComponent, imageTitle, this.siteDto.siteID, () => { });
  }

  async saveScratchCard() {

    this.scratchCardDto.siteId = this.siteDto.siteID;

    if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.siteId)) {
      this.dialogService.openAlertModal("Alert", "Please select unit", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.description)) {
      this.dialogService.openAlertModal("Alert", "Please enter scratch card name", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter start date", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter end date", () => { });
      return;
    }else if (new Date(this.startDate).valueOf() > new Date(this.endDate).valueOf()) {
      this.dialogService.openAlertModal("Alert", "Start date cannot be greater than scratch end date", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.tileImagePath)) {
      this.dialogService.openAlertModal("Alert", "Please tile image", () => { });
      return;
    }
    else {

      this.scratchCardDto.scratchCardImage = 'https://tsgtfstrapiqas.blob.core.windows.net/uploads/Promotions_button_f4dbcc87c1.png';
      this.scratchCardDto.startDateTime = this.startDate.toISOString().slice(0, 10);
      this.scratchCardDto.endDateTime = this.endDate.toISOString().slice(0, 10);
      this.loading = true;
      (await this.scratchCardService.addScratchCard(this.scratchCardDto)).subscribe(result => {
        this.loading = false; 
        this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
        this.goToPageTwoParams('modify-scratch-card', this.scratchCardDto.siteId, result.data);      
      },
        error => {
          this.loading = false;
          this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        });
    }
  }
}
