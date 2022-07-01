import { Component, Input, OnInit } from '@angular/core';
import { GamingPointsUnitDto } from 'src/app/model/Dtos/mdm-patron/gamingPointsUnitDto';
import { GamingPointsService } from 'src/app/service/mdm-patron/gaming-points.service';

@Component({
  selector: 'app-gaming-points-unit',
  templateUrl: './gaming-points-unit.component.html',
  styleUrls: ['./gaming-points-unit.component.css']
})
export class GamingPointsUnitComponent implements OnInit {

  @Input() siteId: number;
  @Input() patronNumber: string;
  @Input() tsogosunId: string;
  gamingPointsUnitDto = {} as GamingPointsUnitDto | undefined;
  step = 0;
  
  constructor(private gamingPointsService : GamingPointsService) { }

  async ngOnInit() {

    this.gamingPointsUnitDto = await this.gamingPointsService.getUnitGamingPoints(this.siteId.toString(), this.patronNumber);

  }

  //control collapsable panels
  setStep(index: number) {
    this.step = index;
  }
}
