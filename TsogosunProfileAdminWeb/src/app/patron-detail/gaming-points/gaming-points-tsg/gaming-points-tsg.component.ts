import { Component, Input, OnInit } from '@angular/core';
import { GamingPointsTSGDto } from 'src/app/model/Dtos/mdm-patron/gamingPointsTSGDto';
import { GamingPointsService } from 'src/app/service/mdm-patron/gaming-points.service';

@Component({
  selector: 'app-gaming-points-tsg',
  templateUrl: './gaming-points-tsg.component.html',
  styleUrls: ['./gaming-points-tsg.component.css']
})
export class GamingPointsTsgComponent implements OnInit {

  gamingPointsTSGDto = {} as GamingPointsTSGDto | undefined ;
  @Input() tsogosunId: string;
  step = 0;

  constructor(private gamingPointsService : GamingPointsService) { }

  async ngOnInit() {
    this.gamingPointsTSGDto = await this.gamingPointsService.getTSGGamingPoints(this.tsogosunId);
  }

  //control collapsable panels
  setStep(index: number) {
    this.step = index;
  }
}
