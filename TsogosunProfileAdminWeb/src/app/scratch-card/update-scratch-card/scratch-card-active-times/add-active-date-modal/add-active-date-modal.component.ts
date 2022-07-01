import { DatePipe } from '@angular/common'
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ScratchCardActiveTimesDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardActiveTimesDto';
import { RequestAddUpdateScratchCardActiveTime } from 'src/app/model/request/profile-rewards-admin/requestAddUpdateScratchCardActiveTime';
import { ScratchCardActiveTimesService } from 'src/app/service/profile-rewards-admin/scratch-card-active-times.service';
import { ModalValidationParams } from 'src/app/shared/dialog/modal-validation-params';
import { SharedFunction } from 'src/app/shared/shared-function';
import { AddActiveDateModal } from './add-active-date-modal';

@Component({
  selector: 'app-add-active-date-modal',
  templateUrl: './add-active-date-modal.component.html',
  styleUrls: ['./add-active-date-modal.component.css']
})
export class AddActiveDateModalComponent extends ModalValidationParams{

  startDate: Date;
  startTime = new Date();
  endDate: Date;
  endTime = new Date();
  bsValue = new Date;

  addActiveDateModal = {} as AddActiveDateModal;
  scratchCardActiveTime = {} as ScratchCardActiveTimesDto;
  requestAddUpdateScratchCardActiveTime = {} as RequestAddUpdateScratchCardActiveTime;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public datepipe: DatePipe,
              private scratchCardActiveTimesService: ScratchCardActiveTimesService) {
          super();

    this.addActiveDateModal = data.message;
    this.scratchCardActiveTime.scratchCardUID = this.addActiveDateModal.scratchCardActiveTimesDto.scratchCardUID;

  }

  async saveScratchActiveTimes() {

    this.resetValidationFields();

    if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
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
    else if (new Date(this.startDate).valueOf() > new Date(this.endDate).valueOf()) {
      this.errorMessage = "Start date cannot be greater that end date";
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

      this.scratchCardActiveTime.startDateTime = this.startDate.toISOString().slice(0, 10);
      this.scratchCardActiveTime.endDateTime = this.endDate.toISOString().slice(0, 10);
      this.requestAddUpdateScratchCardActiveTime.startTime = this.datepipe.transform(this.startTime, 'yyyy/MM/dd hh:mm:ss a');
      this.requestAddUpdateScratchCardActiveTime.endTime = this.datepipe.transform(this.endTime, 'yyyy/MM/dd hh:mm:ss a');
      this.requestAddUpdateScratchCardActiveTime.scratchCardActiveTimesDto = this.scratchCardActiveTime;
      this.loading = true;
      (await this.scratchCardActiveTimesService.addScratchCardActiveTimes(this.requestAddUpdateScratchCardActiveTime, this.addActiveDateModal.siteId)).subscribe(result => {
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
