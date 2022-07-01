import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ScratchCardDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardService } from 'src/app/service/profile-rewards-admin/scratch-card.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { ScratchCardStrapiImagesComponent } from '../scratch-card-strapi-images/scratch-card-strapi-images.component';
import { TileImagesComponent } from '../scratch-card-strapi-images/tile-images/tile-images.component';


@Component({
  selector: 'app-update-scratch-card',
  templateUrl: './update-scratch-card.component.html',
  styleUrls: ['./update-scratch-card.component.css']
})
export class UpdateScratchCardComponent extends ModalResetParams implements OnInit {

  userSites: SiteDto[] = [];
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

    this.scratchCardDto.siteId = Number(this.route.snapshot.params.siteId);
    this.scratchCardDto.scratchCardUID = this.route.snapshot.params.scratchCardId;
    this.userSites = this.getUserSitesBySection(this.user, SectionUtility.ScratchMaintanance);
    this.siteFullName = this.userSites.find(s => s.siteID == Number(this.route.snapshot.params.siteId)).siteFullName;
    this.scratchCardDto = await this.scratchCardService.getScratchCardsByUID(this.route.snapshot.params.scratchCardId, this.route.snapshot.params.siteId);
    this.startDate = new Date(this.scratchCardDto.startDateTime);
    this.endDate = new Date(this.scratchCardDto.endDateTime);
  }

  async canViewScratchCardImage() {
    return SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.scratchCardImage) == true ? false : true;
  }

  async changeStatus() {
    this.scratchCardDto.status = this.scratchCardDto.isActive == true ? 'Active' : 'Not Active';
  }

  goToLink(url: string) {
    window.open(url, "_blank");
  }

  async updateScratchCardImage(imageTitle: string) {
    if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.siteId)) {
      this.dialogService.openAlertModal("Alert", "Units required", () => { });
      return;
    }

    imageTitle = `${this.siteFullName} - ${imageTitle}`;
    this.scratchCardDto.scratchCardImage = await this.dialogService.openReturnModalService(TileImagesComponent, imageTitle, this.scratchCardDto.siteId, () => { });
  }

  async updateScratchCardTileImage(imageTitle: string) {
    if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.siteId)) {
      this.dialogService.openAlertModal("Alert", "Units required", () => { });
      return;
    }

    imageTitle = `${this.siteFullName} - ${imageTitle}`;
    this.scratchCardDto.tileImagePath = await this.dialogService.openReturnModalService(TileImagesComponent, imageTitle, this.scratchCardDto.siteId, () => { });
  }

  async updateScratchCard() {

    this.scratchCardDto.scratchCardUID = this.route.snapshot.params.scratchCardId;

    if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.description)) {
      this.dialogService.openAlertModal("Alert", "Please enter scratch card name", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter start date", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter end date", () => { });
      return;
    }
    else if (new Date(this.startDate).valueOf() > new Date(this.endDate).valueOf()) {
      this.dialogService.openAlertModal("Alert", "Start date cannot be greater than scratch end date", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.tileImagePath)) {
      this.dialogService.openAlertModal("Alert", "Please tile image", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.scratchCardDto.isActive)) {
      this.dialogService.openAlertModal("Alert", "Please select status", () => { });
      return;
    }

    else {

      this.scratchCardDto.startDateTime = this.startDate.toISOString().slice(0, 10);
      this.scratchCardDto.endDateTime = this.endDate.toISOString().slice(0, 10);
      this.loading = true; 
      (await this.scratchCardService.updateScratchCard(this.scratchCardDto)).subscribe(result => {
        this.loading = false; 
        this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
      },
        error => {
          this.loading = false; 
          this.dialogService.openAlertModal("Alert", `${error.message}`, () => { });
        });
    }
  }
}
