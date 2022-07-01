import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ScratchCardPrizeDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardPrizeDto';
import { LosingImagesComponent } from 'src/app/scratch-card/scratch-card-strapi-images/losing-images/losing-images.component';
import { WinningImagesComponent } from 'src/app/scratch-card/scratch-card-strapi-images/winning-images/winning-images.component';
import { ScratchCardPrizeService } from 'src/app/service/profile-rewards-admin/scratch-card-prize.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalValidationParams } from 'src/app/shared/dialog/modal-validation-params';
import { SharedFunction } from 'src/app/shared/shared-function';
import { ConfigurePriceModal } from './configure-price-modal';

@Component({
  selector: 'app-configure-price-modal',
  templateUrl: './configure-price-modal.component.html',
  styleUrls: ['./configure-price-modal.component.css']
})
export class ConfigurePriceModalComponent extends ModalValidationParams implements OnInit {

  scratchCardPrizeDto = {} as ScratchCardPrizeDto;
  configurePriceModal = {} as ConfigurePriceModal;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    public dialogService: DialogService,
    private scratchCardPrizeService: ScratchCardPrizeService) {
    super();
    this.configurePriceModal = data.message;
  }

  async ngOnInit() {

  }

  async addWinningTile(imageTitle: string) {
    imageTitle = `${this.configurePriceModal.siteFullName} - ${imageTitle}`;
    this.scratchCardPrizeDto.winingImagePath = await this.dialogService.openReturnModalService(WinningImagesComponent, imageTitle, this.configurePriceModal.siteId, () => { });
  }

  async addRegretTile(imageTitle: string) {
    imageTitle = `${this.configurePriceModal.siteFullName} - ${imageTitle}`;
    this.scratchCardPrizeDto.losingTileImagePath = await this.dialogService.openReturnModalService(LosingImagesComponent, imageTitle, this.configurePriceModal.siteId, () => { });
  }

  numberOnly(event): boolean {
    return SharedFunction.numberOnly(event);
  }

  async savePrize() {

    this.resetValidationFields();

    if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.prizeTypeID)) {
      this.errorMessage = "Please Select Prize Type";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.numberOfPrizes)) {
      this.errorMessage = "Please Enter Total Prizes";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.startRankID)) {
      this.errorMessage = "Please Enter Start Rank";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.endRankID)) {
      this.errorMessage = "Please Enter End Rank";
      this.showErrorMessage = true;
      return;
    }
    else if (Number(this.scratchCardPrizeDto.startRankID) > Number(this.scratchCardPrizeDto.endRankID)) {
      this.errorMessage = "Start Rank cannot Be Greater Than End Rank";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.winningMessage)) {
      this.errorMessage = "Please Enter Winning Message";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.winingImagePath)) {
      this.errorMessage = "Please Enter Winning Tile";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.regretMessage)) {
      this.errorMessage = "Please Enter Regret Message";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardPrizeDto.losingTileImagePath)) {
      this.errorMessage = "Please Enter Losing Tile";
      this.showErrorMessage = true;
      return;
    }
    else {
      this.loading = true;
      this.scratchCardPrizeDto.scratchCardUID = this.configurePriceModal.scratchCardUID;
      this.scratchCardPrizeDto.siteId = Number(this.configurePriceModal.siteId.toString());
      (await this.scratchCardPrizeService.addScratchCardPrize(this.scratchCardPrizeDto)).subscribe(result => {
        this.loading = false;
        this.successMessage = result.message;
        this.showSuccessMessage = true;
        this.scratchCardPrizeDto.prizeTypeID = null;
        this.scratchCardPrizeDto.startRankID = null;
        this.scratchCardPrizeDto.endRankID = null;
        this.scratchCardPrizeDto.winningMessage = null;
        this.scratchCardPrizeDto.winingImagePath = null;
        this.scratchCardPrizeDto.regretMessage = null;
        this.scratchCardPrizeDto.numberOfPrizes = null;
        this.scratchCardPrizeDto.losingTileImagePath = null;
      },
        error => {
          this.errorMessage = error.message;
          this.showErrorMessage = true;
          this.loading = false;
        });
    }
  }
}