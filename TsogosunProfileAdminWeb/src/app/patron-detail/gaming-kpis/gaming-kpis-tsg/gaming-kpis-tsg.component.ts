import { Component, Input, OnInit } from '@angular/core';
import { GamingKPISDeffinitionDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISDeffinitionDto';
import { GamingKPISTSGDto } from 'src/app/model/Dtos/mdm-patron/gamingKPISTSGDto';
import { RequestGamingKPISTSG } from 'src/app/model/request/mdm-patron/requestGamingKPISTSG';
import { GamingKPISService } from 'src/app/service/mdm-patron/gaming-kpis.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-gaming-kpis-tsg',
  templateUrl: './gaming-kpis-tsg.component.html',
  styleUrls: ['./gaming-kpis-tsg.component.css']
})
export class GamingKpisTsgComponent implements OnInit {

  @Input() tsogosunId: string;
  startDate: Date;
  endDate: Date;
  bsValue = new Date;
  gamingKPISTSGDto = {} as GamingKPISTSGDto | undefined;
  requestGamingKPISTSG = {} as RequestGamingKPISTSG;
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

    this.requestGamingKPISTSG.startDate = this.startDate.toISOString().slice(0,10);
    this.requestGamingKPISTSG.endDate = this.endDate.toISOString().slice(0,10);
    this.requestGamingKPISTSG.tsogosunId = Number(this.tsogosunId);
    this.gamingKPISTSGDto = await this.gamingKPISService.getTSGGamingKPIS(this.requestGamingKPISTSG);
  }

  async openDefinitionsModal()
  {
    this.gamingKPISDeffinitions = await this.gamingKPISService.getGamingKPISDefinitions();
    this.dialogService.openGamingKPISDefinitionModal(`Gaming Definitions`, this.gamingKPISDeffinitions, () => { });
    
  }
}
