import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PatronFreePlayDto } from 'src/app/model/Dtos/profile-admin/patronFreePlayDto';
import { ModalType } from 'src/app/shared/dialog/modal-type-enum';

@Component({
  selector: 'app-free-play-otp-modal',
  templateUrl: './free-play-otp-modal.component.html',
  styleUrls: ['./free-play-otp-modal.component.css']
})
export class FreePlayOtpModalComponent {

  modalTitle: string;
  patronFreePlayDto: PatronFreePlayDto;
  modalType:ModalType = ModalType.INFO;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.modalTitle = data.title;
    this.patronFreePlayDto = data.message;
    this.modalType = data.type;
  }
}
