import { DatePipe } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ScratchCardActiveTimesDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardActiveTimesDto';
import { RequestAddUpdateScratchCardActiveTime } from 'src/app/model/request/profile-rewards-admin/requestAddUpdateScratchCardActiveTime';
import { ScratchCardActiveTimesService } from 'src/app/service/profile-rewards-admin/scratch-card-active-times.service';
import { ModalValidationParams } from 'src/app/shared/dialog/modal-validation-params';
import { SharedFunction } from 'src/app/shared/shared-function';
import { AddActiveDateModal } from '../add-active-date-modal/add-active-date-modal';

@Component({
  selector: 'app-update-active-date-modal',
  templateUrl: './update-active-date-modal.component.html',
  styleUrls: ['./update-active-date-modal.component.css']
})
export class UpdateActiveDateModalComponent extends ModalValidationParams{

  startDate: Date;
  startTime = new Date();
  endDate: Date;
  endTime = new Date();
  bsValue = new Date; 
  addActiveDateModal = {} as AddActiveDateModal;
  scratchCardActiveTime = {} as ScratchCardActiveTimesDto;
  requestAddUpdateScratchCardActiveTime = {} as RequestAddUpdateScratchCardActiveTime;
  

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              @Inject(LOCALE_ID) public locale: string,
              public datepipe: DatePipe,
              private scratchCardActiveTimesService: ScratchCardActiveTimesService) {
            super();

    this.addActiveDateModal = data.message;
    this.scratchCardActiveTime = this.addActiveDateModal.scratchCardActiveTimesDto;
    this.scratchCardActiveTime.scratchCardReleaseID = this.addActiveDateModal.scratchCardActiveTimesDto.scratchCardReleaseID;
    this.scratchCardActiveTime.scratchCardUID = this.addActiveDateModal.scratchCardActiveTimesDto.scratchCardUID;    
    this.startDate =   new Date(this.scratchCardActiveTime.startDateTime);
    this.startTime =  this.scratchCardActiveTime.startDateTime;
    this.endDate =   new Date(this.scratchCardActiveTime.endDateTime);
    this.endTime =  this.scratchCardActiveTime.endDateTime;
 

  }

  async changeStatus() {
    this.scratchCardActiveTime.status = this.scratchCardActiveTime.isActive == true ? 'Active' : 'Not Active';
  }

  async updateScratchActiveTimes() {

    this.resetValidationFields();

    if (!SharedFunction.checkUndefinedObjectValue(this.showSuccessMessage)) {
      this.errorMessage = "Please enter start date";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.startTime)) {
      this.errorMessage = "Please enter start time";
      this.showErrorMessage = true;
      return;
    }
    else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.errorMessage = "Please enter end date";
      this.showErrorMessage = true;
      return;
    }   
    else if (!SharedFunction.checkUndefinedObjectValue(this.endTime)) {
      this.errorMessage = "Please enter end time";
      this.showErrorMessage = true;
      return;
    }
    else if (new Date(this.startDate).valueOf() <
      new Date(this.addActiveDateModal.scratchCardStartDateNumber).valueOf()) {
      this.errorMessage = "Start date cannot be less than scratch start date";
      this.showErrorMessage = true;
      return;
    }
    else if (new Date(this.endDate).valueOf() >
      new Date(this.addActiveDateModal.scratchCardEndDateNumber).valueOf()) {
      this.errorMessage = "End date cannot be greater than scratch end date";
      this.showErrorMessage = true;
      return;
    }
    else {
      this.scratchCardActiveTime.startDateTime = this.startDate.toISOString().slice(0,10);
      this.scratchCardActiveTime.endDateTime = this.endDate.toISOString().slice(0,10);
      this.requestAddUpdateScratchCardActiveTime.startTime = this.datepipe.transform(this.startTime, 'yyyy/MM/dd hh:mm:ss a');
      this.requestAddUpdateScratchCardActiveTime.endTime = this.datepipe.transform(this.endTime, 'yyyy/MM/dd hh:mm:ss a');

      this.requestAddUpdateScratchCardActiveTime.scratchCardActiveTimesDto = this.scratchCardActiveTime; 
      this.loading = true;
      (await this.scratchCardActiveTimesService.updateScratchCardActiveTimes(this.requestAddUpdateScratchCardActiveTime, this.addActiveDateModal.siteId)).subscribe(result => {
        this.loading = false;
        this.successMessage = result.message;
        this.showSuccessMessage = true;
      },
        error => {
          this.loading = false;
          this.errorMessage = error.error.message;
          this.showErrorMessage = true;
        });
    }
  }
}

