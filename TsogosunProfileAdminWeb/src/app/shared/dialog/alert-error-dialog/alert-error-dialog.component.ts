import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ModalType } from '../modal-type-enum';

@Component({
  selector: 'app-alert-error-dialog',
  templateUrl: './alert-error-dialog.component.html',
  styleUrls: ['./alert-error-dialog.component.css']
})
export class AlertErrorDialogComponent {

  modalTitle: string;
  modalMessage: string;
  modalType:ModalType = ModalType.INFO;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.modalTitle = data.title;
    this.modalMessage = data.message;
    this.modalType = data.type;
  }
}
