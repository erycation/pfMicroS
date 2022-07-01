import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RegisteredOtherSitesDto } from 'src/app/model/Dtos/mdm-patron/registeredOtherSitesDto';
import { IGTPatronSearchAddressDto } from 'src/app/model/Dtos/ms-patron-details/igtPatronSearchAddressDto';
import { PatronAddressSearchDto } from 'src/app/model/Dtos/ms-patron-details/patronAddressSearchDto';
import { UnconfirmedIGTPatronDetailsInfoDto } from 'src/app/model/Dtos/ms-patron-details/unconfirmedIGTPatronDetailsInfoDto';
import { TitleDto } from 'src/app/model/Dtos/profile-admin/titleDto';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { MSPatronDetailsService } from 'src/app/service/ms-patron-details/ms-patron-details.service';
import { UserService } from 'src/app/service/profile-admin/user-service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { IgtPatronSearchAddressComponent } from './igt-patron-search-address/igt-patron-search-address.component';

@Component({
  selector: 'app-update-patron-details-igt',
  templateUrl: './update-patron-details-igt.component.html',
  styleUrls: ['./update-patron-details-igt.component.css']
})
export class UpdatePatronDetailsIgtComponent extends ModalResetParams implements OnInit {

  unconfirmedIGTPatronDetailsInfoDto = {} as UnconfirmedIGTPatronDetailsInfoDto;
  igtPatronSearchAddressDto = {} as IGTPatronSearchAddressDto; 
  registeredOtherSitesDto = {} as RegisteredOtherSitesDto;
  titlesDto: TitleDto[] = [];
  insertedDate: string;
  showidPassImage: boolean = false;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private mspatronDetailsService: MSPatronDetailsService,
    private userService: UserService,
    private route: ActivatedRoute,
    private dialogService: DialogService,
    private patronService: PatronService,) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }

  async ngOnInit() {

    this.titlesDto = await this.userService.getUserTitles();
    this.unconfirmedIGTPatronDetailsInfoDto = await this.mspatronDetailsService.getUnconfirmedIGTPatronDetailsByUserId(this.route.snapshot.params.userId);
    this.insertedDate = SharedFunction.formatDateSlash(this.unconfirmedIGTPatronDetailsInfoDto.insertedDate);
    this.unconfirmedIGTPatronDetailsInfoDto.birthDate = SharedFunction.parse(this.unconfirmedIGTPatronDetailsInfoDto.birthDate);
    this.registeredOtherSitesDto = await this.patronService.patronRegisteredOtherSites(this.unconfirmedIGTPatronDetailsInfoDto.idpassportNO);
    this.showidPassImage = SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.formatIdPassImage) ? false : true;
    this.unconfirmedIGTPatronDetailsInfoDto.idPassImage = this.unconfirmedIGTPatronDetailsInfoDto.formatIdPassImage

  }

  async openSearchAddressModal() {

    this.igtPatronSearchAddressDto.city = this.unconfirmedIGTPatronDetailsInfoDto.city;
    this.igtPatronSearchAddressDto.country = this.unconfirmedIGTPatronDetailsInfoDto.country;
    this.igtPatronSearchAddressDto.postalCode = this.unconfirmedIGTPatronDetailsInfoDto.postalCode;
    this.igtPatronSearchAddressDto.province = this.unconfirmedIGTPatronDetailsInfoDto.province;
    this.igtPatronSearchAddressDto.suburb = this.unconfirmedIGTPatronDetailsInfoDto.suburb;
    this.igtPatronSearchAddressDto.siteId = this.route.snapshot.params.siteId;
    this.igtPatronSearchAddressDto.isSuburbCorrect = this.unconfirmedIGTPatronDetailsInfoDto.isSuburbCorrect;
    this.igtPatronSearchAddressDto.isCityCorrect = this.unconfirmedIGTPatronDetailsInfoDto.isCityCorrect;
    this.igtPatronSearchAddressDto.isProvinceCorrect = this.unconfirmedIGTPatronDetailsInfoDto.isProvinceCorrect;
    this.igtPatronSearchAddressDto.isCountryCorrect = this.unconfirmedIGTPatronDetailsInfoDto.isCountryCorrect;
    this.igtPatronSearchAddressDto.isPostalCodeCorrect = this.unconfirmedIGTPatronDetailsInfoDto.isPostalCodeCorrect;
    this.igtPatronSearchAddressDto.isAddressCorrect = this.unconfirmedIGTPatronDetailsInfoDto.isAddressCorrect;
    
    await this.dialogService.openReturnModalService(IgtPatronSearchAddressComponent, `Search Gamesmart Address `, this.igtPatronSearchAddressDto, () => { });
    if (SharedFunction.checkUndefinedObjectValue(this.igtPatronSearchAddressDto?.confirmedPcId)) {
      this.unconfirmedIGTPatronDetailsInfoDto.pcId = this.igtPatronSearchAddressDto?.confirmedPcId;
      this.unconfirmedIGTPatronDetailsInfoDto.city = this.igtPatronSearchAddressDto.confirmedTown;
      this.unconfirmedIGTPatronDetailsInfoDto.country = this.igtPatronSearchAddressDto.confirmedCountry;
      this.unconfirmedIGTPatronDetailsInfoDto.postalCode = this.igtPatronSearchAddressDto.confirmedPostalCode;
      this.unconfirmedIGTPatronDetailsInfoDto.province = this.igtPatronSearchAddressDto.confirmedProvDescription;
      this.unconfirmedIGTPatronDetailsInfoDto.suburb = this.igtPatronSearchAddressDto.confirmedArea;
      this.unconfirmedIGTPatronDetailsInfoDto.isSuburbCorrect = this.igtPatronSearchAddressDto.isSuburbCorrect;
      this.unconfirmedIGTPatronDetailsInfoDto.isCityCorrect = this.igtPatronSearchAddressDto.isCityCorrect;
      this.unconfirmedIGTPatronDetailsInfoDto.isProvinceCorrect = this.igtPatronSearchAddressDto.isProvinceCorrect;
      this.unconfirmedIGTPatronDetailsInfoDto.isCountryCorrect = this.igtPatronSearchAddressDto.isCountryCorrect;
      this.unconfirmedIGTPatronDetailsInfoDto.isPostalCodeCorrect = this.igtPatronSearchAddressDto.isPostalCodeCorrect;
      this.unconfirmedIGTPatronDetailsInfoDto.isAddressCorrect = this.igtPatronSearchAddressDto.isAddressCorrect;
    }
  }

  async updatePatronDetails() {

   if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.title)) {
      this.dialogService.openAlertModal("Alert", "Please select title", () => { });
      return;
    }  else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.firstName)) {
      this.dialogService.openAlertModal("Alert", "Please enter name", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.lastName)) {
      this.dialogService.openAlertModal("Alert", "Please enter surname", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.gender)) {
      this.dialogService.openAlertModal("Alert", "Please select gender", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.nationality)) {
      this.dialogService.openAlertModal("Alert", "Please enter nationality", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.idpassportNO)) {
      this.dialogService.openAlertModal("Alert", "Please enter ID/Passport Number", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.birthDate)) {
      this.dialogService.openAlertModal("Alert", "Please enter birthday date ", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.idPassCountry)) {
      this.dialogService.openAlertModal("Alert", "Please enter ID/Passport country ", () => { });
      return;    
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.mobileNumber)) {
      this.dialogService.openAlertModal("Alert", "Please enter mobile number", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.emailAddress)) {
      this.dialogService.openAlertModal("Alert", "Please enter email address", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.occupation)) {
      this.dialogService.openAlertModal("Alert", "Please enter occupation ", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.address1)) {
      this.dialogService.openAlertModal("Alert", "Please enter house no and street name", () => { });
      return;
    }else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.address2)) {
      this.dialogService.openAlertModal("Alert", "Please enter complex/building ", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.pcId)) {
      this.dialogService.openAlertModal("Alert", "Please verify address", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.unconfirmedIGTPatronDetailsInfoDto.notes)) {
      this.dialogService.openAlertModal("Alert", "Please enter notes", () => { });
      return;
    }
    else {
      this.unconfirmedIGTPatronDetailsInfoDto.siteId = this.route.snapshot.params.siteId;
      //this.unconfirmedIGTPatronDetailsInfoDto.idPassImage = '';
      this.unconfirmedIGTPatronDetailsInfoDto.adminUserName = this.user.username;
      this.loading = true;
      (await this.mspatronDetailsService.updateUnconfirmIGTPatronDetails(this.unconfirmedIGTPatronDetailsInfoDto)).subscribe(result => {
        this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });        
        this.loading = false;
        this.goToPageTwoParams('approved-submit-igt',this.unconfirmedIGTPatronDetailsInfoDto.siteId, this.route.snapshot.params.userId);
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
