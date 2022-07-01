import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RegisteredOtherSitesDto } from 'src/app/model/Dtos/mdm-patron/registeredOtherSitesDto';
import { ConfirmPlayerToSubmitGamingDto } from 'src/app/model/Dtos/ms-patron-details/confirmPlayerToSubmitGamingDto';
import { GMSConfirmedPatronDetailsDto } from 'src/app/model/Dtos/ms-patron-details/gmsConfirmedPatronDetailsDto';
import { GMSPatronDetails } from 'src/app/model/Dtos/ms-patron-details/gmsPatronDetails';
import { GMDocumentTypeDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmDocumentTypeDto';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { GMSPatronDetailsService } from 'src/app/service/ms-patron-details/gms-patron-details.service';
import { MSPatronDetailsService } from 'src/app/service/ms-patron-details/ms-patron-details.service';
import { GamesmartDocumentTypeService } from 'src/app/service/profile-admin/gamesmart-document-type.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-approved-submit-to-gamesmart',
  templateUrl: './approved-submit-to-gamesmart.component.html',
  styleUrls: ['./approved-submit-to-gamesmart.component.css']
})
export class ApprovedSubmitToGamesmartComponent extends ModalResetParams implements OnInit {

  birthDate:string;
  expiryDate:string;
  dateRequested:string;
  gmsConfirmedPatronDetailsDto = {} as GMSConfirmedPatronDetailsDto;
  gmsPatronDetails = {} as GMSPatronDetails;
  confirmPlayerToSubmitGamingDto = {} as ConfirmPlayerToSubmitGamingDto;
  registeredOtherSitesDto = {} as RegisteredOtherSitesDto;
  gmdocumentTypesDto: GMDocumentTypeDto[] = [];
  showidPassImage: boolean = false;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private route: ActivatedRoute,
    private dialogService: DialogService,
    private mspatronDetailsService : MSPatronDetailsService,
    private gmspatronDetailsService : GMSPatronDetailsService,
    private gamesmartDocumentTypeService: GamesmartDocumentTypeService,
    private patronService: PatronService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }

  async ngOnInit() {
    this.gmdocumentTypesDto = await this.gamesmartDocumentTypeService.getGMDocumentTypesBySiteId(this.route.snapshot.params.siteId);
    this.dateRequested = new Date().toISOString().slice(0,10);
    this.gmsConfirmedPatronDetailsDto = await this.mspatronDetailsService.getConfirmedPatronDetailsFromGamesmartByUserId(this.route.snapshot.params.userId, this.route.snapshot.params.siteId);
    this.birthDate = this.formatDate(this.gmsConfirmedPatronDetailsDto.birthDate);
    this.expiryDate = SharedFunction.checkUndefinedObjectValue(this.gmsConfirmedPatronDetailsDto.documentExpireDate) ? this.formatDate(this.gmsConfirmedPatronDetailsDto.documentExpireDate) : null;
    this.registeredOtherSitesDto = await this.patronService.patronRegisteredOtherSites(this.gmsConfirmedPatronDetailsDto.idpassportNO);
    this.showidPassImage = SharedFunction.checkUndefinedObjectValue(this.gmsConfirmedPatronDetailsDto.formatIdPassImage) ? false : true;
    this.gmsConfirmedPatronDetailsDto.idpassImage = !this.showidPassImage ? null : this.gmsConfirmedPatronDetailsDto.formatIdPassImage;  
  }

  async createProfileToGamesmart()
  {
    this.gmsPatronDetails.idpassportNumber = this.gmsConfirmedPatronDetailsDto.idpassportNO;
    this.gmsPatronDetails.countryOfIssue = this.gmsConfirmedPatronDetailsDto.idPassCountry;
    this.gmsPatronDetails.nationality = this.gmsConfirmedPatronDetailsDto.nationality;
    this.gmsPatronDetails.firstName = this.gmsConfirmedPatronDetailsDto.firstName;
    this.gmsPatronDetails.lastName = this.gmsConfirmedPatronDetailsDto.lastName;
    this.gmsPatronDetails.birthday = this.gmsConfirmedPatronDetailsDto.birthDate;
    this.gmsPatronDetails.gender = this.gmsConfirmedPatronDetailsDto?.gender.toLocaleLowerCase() == 'male' ? 'M' : 'F';
    this.gmsPatronDetails.address1 = this.gmsConfirmedPatronDetailsDto.address1;
    this.gmsPatronDetails.address2 =  this.gmsConfirmedPatronDetailsDto.address2;
    this.gmsPatronDetails.pcID = this.gmsConfirmedPatronDetailsDto.postalCode;//this.gmsConfirmedPatronDetailsDto.pcId.toString();
    this.gmsPatronDetails.provID = this.gmsConfirmedPatronDetailsDto.provID;
    this.gmsPatronDetails.countryID = this.gmsConfirmedPatronDetailsDto.countryID;
    this.gmsPatronDetails.pipPEP = this.gmsConfirmedPatronDetailsDto.pippep;
    this.gmsPatronDetails.documentType = this.gmsConfirmedPatronDetailsDto.documentTypeId;
    this.gmsPatronDetails.docExpiryDate =  this.gmsConfirmedPatronDetailsDto.documentExpireDate == null ? this.documentNotExpired() : this.gmsConfirmedPatronDetailsDto.documentExpireDate;
    this.gmsPatronDetails.allowCommConsent = true;//to be relook
    this.gmsPatronDetails.allowCommSMS = this.gmsConfirmedPatronDetailsDto.preferredSms;
    this.gmsPatronDetails.allowCommEmail = this.gmsConfirmedPatronDetailsDto.preferredEmail;
    this.gmsPatronDetails.allowCommPhone = this.gmsConfirmedPatronDetailsDto.preferredPhoneCall;
    this.gmsPatronDetails.allowCommPost = this.gmsConfirmedPatronDetailsDto.preferredPost;
    this.gmsPatronDetails.mobileNo = this.gmsConfirmedPatronDetailsDto.mobileNumber;
    this.gmsPatronDetails.landLineNo = this.gmsConfirmedPatronDetailsDto.mobileNumber;
    this.gmsPatronDetails.email = this.gmsConfirmedPatronDetailsDto.emailAddress;
    this.gmsPatronDetails.photo = this.gmsConfirmedPatronDetailsDto.idpassImage;

    this.loading = true;
    (await this.gmspatronDetailsService.addGMSPatronDetails(this.gmsPatronDetails)).subscribe(result => {
      this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
      this.confirmPlayerToSubmitGaming(Number(this.route.snapshot.params.userId), this.gmsConfirmedPatronDetailsDto.confirmedBy);
      this.loading = false;
      this.goToPageNoParams('patron-details');
    },
      error => {
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        this.loading = false;
      });
  }

  async confirmPlayerToSubmitGaming(userDetailId: number, confirmedBy?: string)
  {
    this.confirmPlayerToSubmitGamingDto.userDetailId = userDetailId;
    this.confirmPlayerToSubmitGamingDto.confirmedBy = confirmedBy;
    (await this.mspatronDetailsService.confirmPlayerStatusAfterSubmitGaming(this.confirmPlayerToSubmitGamingDto)).subscribe(result => {
      //this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
    },
      error => {
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
      });
  }

  async redirectToPage(page: string) {
    this.goToPageNoParams(page);
  }
}
