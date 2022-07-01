import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GamesmartPatronSearchAddressDto } from 'src/app/model/Dtos/ms-patron-details/gamesmartPatronSearchAddressDto';
import { GMAddressDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmAddressDto';
import { GMCountryDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmCountryDto';
import { GMProvinceDto } from 'src/app/model/Dtos/profile-admin/gamesmart/gmProvinceDto';
import { RequestGMAddress } from 'src/app/model/request/profile-admin/requestGMAddress';
import { GamesmartAddressService } from 'src/app/service/profile-admin/gamesmart-address.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalValidationParams } from 'src/app/shared/dialog/modal-validation-params';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-gamesmart-patron-search-address',
  templateUrl: './gamesmart-patron-search-address.component.html',
  styleUrls: ['./gamesmart-patron-search-address.component.css']
})
export class GamesmartPatronSearchAddressComponent extends ModalValidationParams implements OnInit {

  requestGMAddress = {} as RequestGMAddress;
  gamesmartPatronSearchAddressDto = {} as GamesmartPatronSearchAddressDto;
  gmCountryDto = {} as GMCountryDto;
  gmCountriesDto: GMCountryDto[] = [];
  gmProvinceDto = {} as GMProvinceDto;
  gmProvinciesDto: GMProvinceDto[] = [];
  gmAddressDto: GMAddressDto[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private gamesmartAddressService: GamesmartAddressService,
    private dialogService: DialogService) {
    super();
    this.gamesmartPatronSearchAddressDto = data.message;
    this.requestGMAddress.siteId = Number(this.gamesmartPatronSearchAddressDto.siteId);
  }

  async ngOnInit() {

    this.gmCountriesDto = await this.gamesmartAddressService.getGMCountriesBySiteId(this.gamesmartPatronSearchAddressDto.siteId);

    if (this.gamesmartPatronSearchAddressDto.isCountryCorrect) {
      this.gmCountryDto = this.gmCountriesDto.find(c => c.country == this.gamesmartPatronSearchAddressDto.country);
      if (SharedFunction.checkUndefinedObjectValue(this.gmCountryDto)) {
        this.gmProvinciesDto = await this.gamesmartAddressService.getGMProvinceByCountryId(this.gamesmartPatronSearchAddressDto.siteId, this.gmCountryDto.countryId.toString());
        if (this.gamesmartPatronSearchAddressDto.isProvinceCorrect) {
          this.gmProvinceDto = this.gmProvinciesDto.find(c => c.province == this.gamesmartPatronSearchAddressDto.province);
          if (SharedFunction.checkUndefinedObjectValue(this.gmProvinceDto)) {
            this.requestGMAddress.provinceId = this.gmProvinceDto.provinceId;
            if (this.gamesmartPatronSearchAddressDto.isCityCorrect) {
              this.requestGMAddress.town = this.gamesmartPatronSearchAddressDto.city;
            }
            if (this.gamesmartPatronSearchAddressDto.isSuburbCorrect) {
              this.requestGMAddress.suburb = this.gamesmartPatronSearchAddressDto.suburb;
            }
            if (this.gamesmartPatronSearchAddressDto.isPostalCodeCorrect) {
              this.requestGMAddress.postalCode = this.gamesmartPatronSearchAddressDto.postalCode;
            }

            await this.loadGMAddress();
          }
        }
      }
    }
  }

  async loadProvinceAssociateWithCountry() {

    //this.gmCountryDto = null;
    //this.gmProvinciesDto = [];

    if (SharedFunction.checkUndefinedObjectValue(this.gmCountryDto)) {
      this.gmProvinciesDto = await this.gamesmartAddressService.getGMProvinceByCountryId(this.gamesmartPatronSearchAddressDto.siteId, this.gmCountryDto.countryId.toString());
    }
  }

  async searchGMPatronAddress() {
    if (!SharedFunction.checkUndefinedObjectValue(this.gmCountryDto.countryId)) {
      this.dialogService.openAlertModal("Alert", "Pelase Select Country", () => { });
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.gmProvinceDto.provinceId)) {
      this.dialogService.openAlertModal("Alert", "Pelase Select Province", () => { });
      return;
    } else {    
      this.requestGMAddress.provinceId = this.gmProvinceDto.provinceId;
      await this.loadGMAddress();
    }
  }

  async loadGMAddress() {
    this.gmAddressDto = await this.gamesmartAddressService.getGMAddressByProvince(this.requestGMAddress);
  }

  async selectAddress(gmAddressDto: GMAddressDto) {
    this.gamesmartPatronSearchAddressDto.confirmedPcId = gmAddressDto.postalCodeId;
    this.gamesmartPatronSearchAddressDto.confirmedArea = gmAddressDto.suburb;
    this.gamesmartPatronSearchAddressDto.confirmedTown = gmAddressDto.town;
    this.gamesmartPatronSearchAddressDto.confirmedProvDescription = gmAddressDto.province;
    this.gamesmartPatronSearchAddressDto.confirmedCountry = gmAddressDto.country;
    this.gamesmartPatronSearchAddressDto.confirmedPostalCode = gmAddressDto.postalCode;
    this.gamesmartPatronSearchAddressDto.isSuburbCorrect = true;
    this.gamesmartPatronSearchAddressDto.isCityCorrect = true;
    this.gamesmartPatronSearchAddressDto.isProvinceCorrect =  true;
    this.gamesmartPatronSearchAddressDto.isCountryCorrect= true;
    this.gamesmartPatronSearchAddressDto.isPostalCodeCorrect = true;
    this.gamesmartPatronSearchAddressDto.isAddressCorrect = true;
  }
}
