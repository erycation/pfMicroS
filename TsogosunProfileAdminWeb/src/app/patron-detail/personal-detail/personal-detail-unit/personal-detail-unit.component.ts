import { Component, Input, OnInit } from '@angular/core';
import { PatronDetailsSiteDto } from 'src/app/model/Dtos/mdm-patron/patronDetailsSiteDto';
import { CommunicationPreferenceDto } from 'src/app/model/Dtos/profile-rewards-admin/communicationPreferenceDto';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { CommunicationPreferenceService } from 'src/app/service/profile-rewards-admin/communication-preference.service';

@Component({
  selector: 'app-personal-detail-unit',
  templateUrl: './personal-detail-unit.component.html',
  styleUrls: ['./personal-detail-unit.component.css']
})
export class PersonalDetailUnitComponent implements OnInit {

  @Input() siteId: number;
  @Input() patronNumber: string;
  @Input() tsogosunId: string;
  patronDetailsSiteDto = {} as PatronDetailsSiteDto | undefined ;
  communicationPreferenceDto : CommunicationPreferenceDto[] = [];
  step = 0;
  
  constructor(private patronService : PatronService,
    private communicationPreferenceService : CommunicationPreferenceService) { }

  async ngOnInit() {

    this.patronDetailsSiteDto = await this.patronService.getPatronBySiteIdAndTsogosunID(this.siteId.toString(), this.patronNumber, this.tsogosunId);
    this.communicationPreferenceDto = await this.communicationPreferenceService.getAllCommunicationPreferencesByPatron(this.patronNumber, this.siteId.toString());

  }

  //control collapsable panels
  setStep(index: number) {
    this.step = index;
  }

}
