import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IGTPatronSearchAddressDto } from 'src/app/model/Dtos/ms-patron-details/igtPatronSearchAddressDto';
import { PatronAddressSearchDto } from 'src/app/model/Dtos/ms-patron-details/patronAddressSearchDto';
import { RequestPatronAddress } from 'src/app/model/request/profile-admin/requestPatronAddress';
import { PatronAddressService } from 'src/app/service/profile-admin/patron-address.service';
import { ModalValidationParams } from 'src/app/shared/dialog/modal-validation-params';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-igt-patron-search-address',
  templateUrl: './igt-patron-search-address.component.html',
  styleUrls: ['./igt-patron-search-address.component.css']
})
export class IgtPatronSearchAddressComponent extends ModalValidationParams implements OnInit {

  igtPatronSearchAddressDto = {} as IGTPatronSearchAddressDto;
  requestPatronAddress = {} as RequestPatronAddress;
  patronAddressSearchDto: PatronAddressSearchDto[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private patronAddressService: PatronAddressService) {
    super();
    this.igtPatronSearchAddressDto = data.message;
  }

  async ngOnInit() {
    if (this.igtPatronSearchAddressDto.isCountryCorrect) {
      this.requestPatronAddress.country = this.igtPatronSearchAddressDto.country;
    }
    if (this.igtPatronSearchAddressDto.isProvinceCorrect) {
      this.requestPatronAddress.province = this.igtPatronSearchAddressDto.province;
    }
    if (this.igtPatronSearchAddressDto.isCityCorrect) {
      this.requestPatronAddress.city = this.igtPatronSearchAddressDto.city;
    }
    if (this.igtPatronSearchAddressDto.isPostalCodeCorrect) {
      this.requestPatronAddress.postalCode = this.igtPatronSearchAddressDto.postalCode;
    }
    if (this.igtPatronSearchAddressDto.isSuburbCorrect) {
      this.requestPatronAddress.suburb = this.igtPatronSearchAddressDto.suburb;
    }
    if (SharedFunction.checkUndefinedObjectValue(this.requestPatronAddress)) {
      await this.searchPatronAddress();
    }
  }

  async searchPatronAddress() {
    this.resetValidationFields();

    if ((!SharedFunction.checkUndefinedObjectValue(this.requestPatronAddress.suburb)) &&
      (!SharedFunction.checkUndefinedObjectValue(this.requestPatronAddress.city)) &&
      (!SharedFunction.checkUndefinedObjectValue(this.requestPatronAddress.province)) &&
      (!SharedFunction.checkUndefinedObjectValue(this.requestPatronAddress.country)) &&
      (!SharedFunction.checkUndefinedObjectValue(this.requestPatronAddress.postalCode))
    ) {
      this.displayDivErrorMessage('Please enter field to search')
      return;
    }

    this.patronAddressSearchDto = await this.patronAddressService.getPatronAddress(this.requestPatronAddress);
  }

  async selectAddress(patronAddressSearchDto: PatronAddressSearchDto) {

    this.igtPatronSearchAddressDto.confirmedPcId = patronAddressSearchDto.pcId;
    this.igtPatronSearchAddressDto.confirmedArea = patronAddressSearchDto.area;
    this.igtPatronSearchAddressDto.confirmedTown = patronAddressSearchDto.town;
    this.igtPatronSearchAddressDto.confirmedProvDescription = patronAddressSearchDto.provDescription;
    this.igtPatronSearchAddressDto.confirmedCountry = patronAddressSearchDto.country;
    this.igtPatronSearchAddressDto.confirmedPostalCode = patronAddressSearchDto.postalCode;
    this.igtPatronSearchAddressDto.isSuburbCorrect = true;
    this.igtPatronSearchAddressDto.isCityCorrect = true;
    this.igtPatronSearchAddressDto.isProvinceCorrect =  true;
    this.igtPatronSearchAddressDto.isCountryCorrect= true;
    this.igtPatronSearchAddressDto.isPostalCodeCorrect = true;
    this.igtPatronSearchAddressDto.isAddressCorrect = true;

  }
}