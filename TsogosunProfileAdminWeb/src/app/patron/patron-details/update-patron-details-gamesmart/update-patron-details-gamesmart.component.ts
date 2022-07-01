import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RegisteredOtherSitesDto } from 'src/app/model/Dtos/mdm-patron/registeredOtherSitesDto';
import { GamesmartPatronSearchAddressDto } from 'src/app/model/Dtos/ms-patron-details/gamesmartPatronSearchAddressDto';
import { PatronAddressSearchDto } from 'src/app/model/Dtos/ms-patron-details/patronAddressSearchDto';
import { UnconfirmedGMSPatronDetailsInfoDto } from 'src/app/model/Dtos/ms-patron-details/unconfirmedGMSPatronDetailsInfoDto';
import { GMDocumentTypeDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmDocumentTypeDto';
import { TitleDto } from 'src/app/model/Dtos/profile-admin/titleDto';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { MSPatronDetailsService } from 'src/app/service/ms-patron-details/ms-patron-details.service';
import { GamesmartDocumentTypeService } from 'src/app/service/profile-admin/gamesmart-document-type.service';
import { UserService } from 'src/app/service/profile-admin/user-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { GamesmartPatronSearchAddressComponent } from './gamesmart-patron-search-address/gamesmart-patron-search-address.component';

@Component({
  selector: 'app-update-patron-details-gamesmart',
  templateUrl: './update-patron-details-gamesmart.component.html',
  styleUrls: ['./update-patron-details-gamesmart.component.css']
})
export class UpdatePatronDetailsGamesmartComponent extends ModalResetParams implements OnInit {

  unconfirmedGMSPatronDetailsInfoDto = {} as UnconfirmedGMSPatronDetailsInfoDto;  
  verifiedPatronAddressSearchDto = {} as PatronAddressSearchDto;
  gamesmartPatronSearchAddressDto = {} as GamesmartPatronSearchAddressDto;
  registeredOtherSitesDto = {} as RegisteredOtherSitesDto;
  titlesDto: TitleDto[] = [];
  gmdocumentTypesDto: GMDocumentTypeDto[] = [];
  gmdocumentTypeDto: GMDocumentTypeDto;
  documentHavExpiredDate: boolean = false;
  insertedDate: string;
  showidPassImage: boolean = false;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private mspatronDetailsService: MSPatronDetailsService,
    private gamesmartDocumentTypeService: GamesmartDocumentTypeService,
    private userService: UserService,
    private route: ActivatedRoute,
    private dialogService: DialogService,
    private patronService: PatronService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }

  async ngOnInit() {

    this.unconfirmedGMSPatronDetailsInfoDto.documentExpireDate = null;
    this.titlesDto = await this.userService.getUserTitles();
    this.unconfirmedGMSPatronDetailsInfoDto = await this.mspatronDetailsService.getUnconfirmedGamesmartPatronDetailsByUserId(this.route.snapshot.params.userId);
    this.insertedDate = SharedFunction.formatDateSlash(this.unconfirmedGMSPatronDetailsInfoDto.insertedDate);
    this.unconfirmedGMSPatronDetailsInfoDto.birthDate = SharedFunction.parse(this.unconfirmedGMSPatronDetailsInfoDto.birthDate);
    this.registeredOtherSitesDto = await this.patronService.patronRegisteredOtherSites(this.unconfirmedGMSPatronDetailsInfoDto.idpassportNO);
    this.gmdocumentTypesDto = await this.gamesmartDocumentTypeService.getGMDocumentTypesBySiteId(this.route.snapshot.params.siteId);
    this.showidPassImage = SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.formatIdPassImage) ? false : true;
    this.unconfirmedGMSPatronDetailsInfoDto.idPassImage = this.unconfirmedGMSPatronDetailsInfoDto.formatIdPassImage
  }

  async openSearchAddressModal() {

    this.gamesmartPatronSearchAddressDto.city = this.unconfirmedGMSPatronDetailsInfoDto.city;
    this.gamesmartPatronSearchAddressDto.country = this.unconfirmedGMSPatronDetailsInfoDto.country;
    this.gamesmartPatronSearchAddressDto.postalCode = this.unconfirmedGMSPatronDetailsInfoDto.postalCode;
    this.gamesmartPatronSearchAddressDto.province = this.unconfirmedGMSPatronDetailsInfoDto.province;
    this.gamesmartPatronSearchAddressDto.suburb = this.unconfirmedGMSPatronDetailsInfoDto.suburb;
    this.gamesmartPatronSearchAddressDto.siteId = this.route.snapshot.params.siteId;
    this.gamesmartPatronSearchAddressDto.isSuburbCorrect = this.unconfirmedGMSPatronDetailsInfoDto.isSuburbCorrect;
    this.gamesmartPatronSearchAddressDto.isCityCorrect = this.unconfirmedGMSPatronDetailsInfoDto.isCityCorrect;
    this.gamesmartPatronSearchAddressDto.isProvinceCorrect = this.unconfirmedGMSPatronDetailsInfoDto.isProvinceCorrect;
    this.gamesmartPatronSearchAddressDto.isCountryCorrect = this.unconfirmedGMSPatronDetailsInfoDto.isCountryCorrect;
    this.gamesmartPatronSearchAddressDto.isPostalCodeCorrect = this.unconfirmedGMSPatronDetailsInfoDto.isPostalCodeCorrect;
    this.gamesmartPatronSearchAddressDto.isAddressCorrect = this.unconfirmedGMSPatronDetailsInfoDto.isAddressCorrect;
    
    await this.dialogService.openReturnModalService(GamesmartPatronSearchAddressComponent, `Search Gamesmart Address `, this.gamesmartPatronSearchAddressDto, () => { });
    if (SharedFunction.checkUndefinedObjectValue(this.gamesmartPatronSearchAddressDto?.confirmedPcId)) {
        this.unconfirmedGMSPatronDetailsInfoDto.pcId = this.gamesmartPatronSearchAddressDto?.confirmedPcId;
        this.unconfirmedGMSPatronDetailsInfoDto.city = this.gamesmartPatronSearchAddressDto?.confirmedTown;
        this.unconfirmedGMSPatronDetailsInfoDto.postalCode = this.gamesmartPatronSearchAddressDto?.confirmedPostalCode;
        this.unconfirmedGMSPatronDetailsInfoDto.province = this.gamesmartPatronSearchAddressDto?.confirmedProvDescription;
        this.unconfirmedGMSPatronDetailsInfoDto.suburb = this.gamesmartPatronSearchAddressDto?.confirmedArea;
        this.unconfirmedGMSPatronDetailsInfoDto.country = this.gamesmartPatronSearchAddressDto?.confirmedCountry;
        this.unconfirmedGMSPatronDetailsInfoDto.isSuburbCorrect = this.gamesmartPatronSearchAddressDto.isSuburbCorrect;
        this.unconfirmedGMSPatronDetailsInfoDto.isCityCorrect = this.gamesmartPatronSearchAddressDto.isCityCorrect;
        this.unconfirmedGMSPatronDetailsInfoDto.isProvinceCorrect = this.gamesmartPatronSearchAddressDto.isProvinceCorrect;
        this.unconfirmedGMSPatronDetailsInfoDto.isCountryCorrect = this.gamesmartPatronSearchAddressDto.isCountryCorrect;
        this.unconfirmedGMSPatronDetailsInfoDto.isPostalCodeCorrect = this.gamesmartPatronSearchAddressDto.isPostalCodeCorrect;
        this.unconfirmedGMSPatronDetailsInfoDto.isAddressCorrect = this.gamesmartPatronSearchAddressDto.isAddressCorrect;
     }
  }

  async validateDocumentExpireDate() {
    if (SharedFunction.checkUndefinedObjectValue(this.gmdocumentTypeDto)) {
      if (this.gmdocumentTypeDto.canExpire) {
        this.documentHavExpiredDate = true;
      }
      else {
        this.documentHavExpiredDate = false;
      }
    }
  }

  async updatePatronDetails() {

   if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.title)) {
      this.dialogService.openAlertModal("Alert", "Please select title", () => { });
      return;
    }  else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.firstName)) {
      this.dialogService.openAlertModal("Alert", "Please enter name", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.lastName)) {
      this.dialogService.openAlertModal("Alert", "Please enter surname", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.gender)) {
      this.dialogService.openAlertModal("Alert", "Please select gender", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.nationality)) {
      this.dialogService.openAlertModal("Alert", "Please enter nationality", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.idpassportNO)) {
      this.dialogService.openAlertModal("Alert", "Please enter ID/Passport Number", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.birthDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter birthday date ", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.idPassCountry)) {
      this.dialogService.openAlertModal("Alert", "Please enter ID/Passport country ", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.pippep)) {
      this.dialogService.openAlertModal("Alert", "Please select PIPPEP status ", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.gmdocumentTypeDto)) {
      this.dialogService.openAlertModal("Alert", "Please select document Type ", () => { });
      return;
    }/* else if (this.gmdocumentTypeDto.canExpire) {
      if (!SharedFunction.checkUndefinedObjectValue(this.patronDetailsInfoDto.documentExpireDate)) {
        this.dialogService.openAlertModal("Alert", "Please enter expired date ", () => { });
        return;
      }
    } */else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.mobileNumber)) {
      this.dialogService.openAlertModal("Alert", "Please enter mobile number", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.emailAddress)) {
      this.dialogService.openAlertModal("Alert", "Please enter email address", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.occupation)) {
      this.dialogService.openAlertModal("Alert", "Please enter occupation ", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.address1)) {
      this.dialogService.openAlertModal("Alert", "Please enter house no and street name", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.address2)) {
      this.dialogService.openAlertModal("Alert", "Please enter complex/building ", () => { });
      return;
    }  else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.pcId)) {
      this.dialogService.openAlertModal("Alert", "Please verify address", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedGMSPatronDetailsInfoDto.notes)) {
      this.dialogService.openAlertModal("Alert", "Please enter notes", () => { });
      return;
    }
    else {
      this.unconfirmedGMSPatronDetailsInfoDto.siteId = this.route.snapshot.params.siteId;
      this.unconfirmedGMSPatronDetailsInfoDto.adminUserName = this.user.username;
      this.unconfirmedGMSPatronDetailsInfoDto.documentTypeId = this.gmdocumentTypeDto.documentTypeID;
      this.loading = true;
      (await this.mspatronDetailsService.updateUnconfirmGamesmartPatronDetails(this.unconfirmedGMSPatronDetailsInfoDto)).subscribe(result => {
        this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
        this.loading = false;
        this.goToPageTwoParams('approved-submit-gamesmart',this.unconfirmedGMSPatronDetailsInfoDto.siteId, this.route.snapshot.params.userId);
      },
        error => {
          this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
          this.loading = false;
        });
    }
  }

  async redirectToPage(page: string) {
    this.goToPageNoParams(page);
  }
}
