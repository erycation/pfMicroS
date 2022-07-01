import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PatronVoucherDto } from 'src/app/model/Dtos/profile-admin/patronVoucherDto';
import { ModalType } from 'src/app/shared/dialog/modal-type-enum';

@Component({
  selector: 'app-voucher-otp-modal',
  templateUrl: './voucher-otp-modal.component.html',
  styleUrls: ['./voucher-otp-modal.component.css']
})
export class VoucherOtpModalComponent  {

  modalTitle: string;
  patronVoucherDto: PatronVoucherDto;
  modalType:ModalType = ModalType.INFO;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.modalTitle = data.title;
    this.patronVoucherDto = data.message;
    this.modalType = data.type;
  }
}