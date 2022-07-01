import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GamingKPISDeffinitionDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISDeffinitionDto';
import { ModalType } from 'src/app/shared/dialog/modal-type-enum';

@Component({
  selector: 'app-gaming-kpis-definition',
  templateUrl: './gaming-kpis-definition.component.html',
  styleUrls: ['./gaming-kpis-definition.component.css']
})
export class GamingKpisDefinitionComponent  {

  modalTitle: string;
  gamingKPISDeffinitions: GamingKPISDeffinitionDto[] = [];
  modalType:ModalType = ModalType.INFO;
  filterByGamingTerm : string = "";

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.modalTitle = data.title;
    this.gamingKPISDeffinitions = data.message;
    this.modalType = data.type;
  }
}

