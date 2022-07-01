import { Component, Input, OnInit } from '@angular/core';
import { PrizeTypeDto } from 'src/app/model/Dtos/profile-rewards-admin/prizeTypeDto';
import { ScratchCardPrizeDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardPrizeDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { PrizeTypeService } from 'src/app/service/profile-rewards-admin/parize-type.service';
import { ScratchCardPrizeService } from 'src/app/service/profile-rewards-admin/scratch-card-prize.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalConfigurePrizeEntity } from 'src/app/shared/dialog/modal-configure-prize-entity';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { ConfigurePriceModal } from './configure-price-modal/configure-price-modal';
import { ConfigurePriceModalComponent } from './configure-price-modal/configure-price-modal.component';
import { UpdateConfigurePriceModal } from './update-configure-price-modal/update-configure-price-modal';
import { UpdateConfigurePriceModalComponent } from './update-configure-price-modal/update-configure-price-modal.component';

@Component({
  selector: 'app-list-scratch-card-prizes',
  templateUrl: './list-scratch-card-prizes.component.html',
  styleUrls: ['./list-scratch-card-prizes.component.css']
})
export class ListScratchCardPrizesComponent implements OnInit {

  user: AuthToken;
  userSites: SiteDto[] = [];
  scratchCardPrizes : ScratchCardPrizeDto[] = [];
  prizeTypeDto: PrizeTypeDto[] = [];
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  modalConfigurePrizeEntity = {} as ModalConfigurePrizeEntity;
 
  @Input() siteId: number;
  @Input() scratchCardId: string;
  @Input() siteFullName: string;

  addConfigurePriceModal = {} as ConfigurePriceModal;
  updateConfigurePriceModal = {} as UpdateConfigurePriceModal;

  constructor(private accountService: AccountService,
              private sharedFunction: SharedFunction,
              public dialogService: DialogService,
              private scratchCardPrizeService : ScratchCardPrizeService,
              private prizeTypeService: PrizeTypeService) { }

  async ngOnInit() {

    this.user = this.accountService.userValue;
    this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.ScratchMaintanance);
    await this.loadScratchCardPrizes();
    
  }

  async loadScratchCardPrizes()
  {

    this.showNoResultsMessage = false;
    this.prizeTypeDto = await this.prizeTypeService.getAllPrizeTypesBySiteId(this.siteId.toString());
    this.scratchCardPrizes = await this.scratchCardPrizeService.getScratchCardPrizeByScratchCardId(this.scratchCardId,this.siteId.toString());

    if (this.scratchCardPrizes?.length == 0) {
      this.showNoResultsMessage = true;
      this.resultsMessage = "No Price configured for scratch.";
    }
  }

  goToLink(url: string) {
    window.open(url, "_blank");
  }

  async configureScratchPrizeCard()
  {
    this.addConfigurePriceModal.siteId = this.siteId.toString();
    this.addConfigurePriceModal.scratchCardUID = this.scratchCardId;
    this.addConfigurePriceModal.siteFullName = this.siteFullName;
    this.addConfigurePriceModal.prizeTypes = this.prizeTypeDto;
    this.addConfigurePriceModal.ranks = this.user?.ranks;
    await this.dialogService.openReturnModalService(ConfigurePriceModalComponent, `Add ScratchCard Prize `, this.addConfigurePriceModal, () => { });
    await this.loadScratchCardPrizes();
  }

  async openUpdateConfigurePrizeModal(scratchCardPrize : ScratchCardPrizeDto)
  {
    this.updateConfigurePriceModal.siteId = this.siteId.toString();
    this.updateConfigurePriceModal.scratchCardUID = this.scratchCardId;
    this.updateConfigurePriceModal.siteFullName = this.siteFullName;
    this.updateConfigurePriceModal.prizeTypes = this.prizeTypeDto;
    this.updateConfigurePriceModal.ranks = this.user?.ranks;
    this.updateConfigurePriceModal.scratchCardPrizeDto = scratchCardPrize;

    await this.dialogService.openReturnModalService(UpdateConfigurePriceModalComponent, `Update ScratchCard Prize `, this.updateConfigurePriceModal, () => { });
    await this.loadScratchCardPrizes();
  }
}
