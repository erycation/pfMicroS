import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PatronDetailsDto } from '../model/Dtos/mdm-patron/patronDetailsDto';
import { PatronStatusSummaryDetailsDto } from '../model/Dtos/mdm-patron/patronStatusSummaryDetailsDto';
import { AccountService } from '../service/account.service';
import { PatronService } from '../service/mdm-patron/patron.service';
import { ModalResetParams } from '../shared/modal-reset-params';
import { SectionUtility } from '../shared/section-utility';
import { SharedFunction } from '../shared/shared-function';

@Component({
  selector: 'app-patron-detail',
  templateUrl: './patron-detail.component.html',
  styleUrls: ['./patron-detail.component.css']
})

export class PatronDetailComponent extends ModalResetParams implements OnInit {

  tsogosunId: string;
  patronStatusSummaryDetailsDto = {} as PatronStatusSummaryDetailsDto | undefined ;
  patronDetailsDto = {} as PatronDetailsDto | undefined ;
  canAccessTSG : Boolean = false;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private patronService: PatronService,
    private route: ActivatedRoute) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.personalDetails);
  }

  async ngOnInit() {
    this.tsogosunId = this.route.snapshot.params.tsogosunId;
    this.patronStatusSummaryDetailsDto = await this.patronService.getPatronSummaryDetailsBytsogosunID(this.tsogosunId);
    this.patronDetailsDto = await this.patronService.getPatronBytsogosunID(this.tsogosunId);
  }
}
