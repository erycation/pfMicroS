
import { Component, Input, OnInit } from '@angular/core';
import { GamingKPISDeffinitionDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISDeffinitionDto';
import { GamingKPISUnitDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISUnitDto';
import { RequestGamingKPISUnit } from 'src/app/model/request/mdm-patron/requestGamingKPISUnit';
import { GamingKPISService } from 'src/app/service/mdm-patron/gaming-kpis.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-gaming-kpis-unit',
  templateUrl: './gaming-kpis-unit.component.html',
  styleUrls: ['./gaming-kpis-unit.component.css']
})
export class GamingKpisUnitComponent implements OnInit {

  @Input() siteId: number;
  @Input() patronNumber: string;
  @Input() tsogosunId: string;
  startDate: Date;
  endDate: Date;
  bsValue = new Date;
  gamingKPISUnitDto = {} as GamingKPISUnitDto | undefined;
  requestGamingKPISUnit = {} as RequestGamingKPISUnit;
  gamingKPISDeffinitions : GamingKPISDeffinitionDto[] = [];

  constructor(private gamingKPISService : GamingKPISService,
              public dialogService: DialogService) { 

              }

  async ngOnInit() {

    var startDateConfig = new Date();
    startDateConfig.setDate(startDateConfig.getDate() - 7);
    this.startDate = startDateConfig;
    this.endDate = new Date();

    await this.loadGamingKPISPerUnit();
  }

  async viewKPISByDate()
  {
    await this.loadGamingKPISPerUnit();
  }

  async loadGamingKPISPerUnit()
  {
    if (!SharedFunction.checkUndefinedObjectValue(this.startDate)) {
      this.dialogService.openAlertModal("Alert", "Please select start date", () => { });
      return;
    } else if (!SharedFunction.checkUndefinedObjectValue(this.endDate)) {
      this.dialogService.openAlertModal("Alert", "Please select end date", () => { });
      return;
    }
    this.requestGamingKPISUnit.siteId = this.siteId;
    this.requestGamingKPISUnit.patronId = Number(this.patronNumber);
    this.requestGamingKPISUnit.startDate = this.startDate.toISOString().slice(0,10);
    this.requestGamingKPISUnit.endDate =  this.endDate.toISOString().slice(0,10);
    this.gamingKPISUnitDto = await this.gamingKPISService.getUnitGamingKPIS(this.requestGamingKPISUnit);
    
  }

  async openDefinitionsModal()
  {
    this.gamingKPISDeffinitions = await this.gamingKPISService.getGamingKPISDefinitions();
    this.dialogService.openGamingKPISDefinitionModal(`Gaming Definitions`, this.gamingKPISDeffinitions, () => { });
    
  }
}
