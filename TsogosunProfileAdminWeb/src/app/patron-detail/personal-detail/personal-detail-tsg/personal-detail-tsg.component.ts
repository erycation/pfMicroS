import { Component, Input, OnInit } from '@angular/core';
import { PatronDetailsDto } from 'src/app/model/Dtos/mdm-patron/patronDetailsDto';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';

@Component({
  selector: 'app-personal-detail-tsg',
  templateUrl: './personal-detail-tsg.component.html',
  styleUrls: ['./personal-detail-tsg.component.css']
})
export class PersonalDetailTsgComponent implements OnInit {

  patronDetailsTsgDto = {} as PatronDetailsDto | undefined ;
  @Input() tsogosunId: string;
  step = 0;
    
  constructor(private patronService : PatronService) { }

  async ngOnInit() {
    this.patronDetailsTsgDto = await this.patronService.getPatronBytsogosunID(this.tsogosunId);
  }

  //control collapsable panels
  setStep(index: number) {
    this.step = index;
  }
}
