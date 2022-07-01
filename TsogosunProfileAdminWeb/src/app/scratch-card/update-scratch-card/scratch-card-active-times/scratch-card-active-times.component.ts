import { Component, Input, OnInit } from '@angular/core';
import { ScratchCardActiveTimesDto } from 'src/app/model/Dtos/profile-rewards-admin/scratchCardActiveTimesDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { AccountService } from 'src/app/service/account.service';
import { ScratchCardActiveTimesService } from 'src/app/service/profile-rewards-admin/scratch-card-active-times.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { AddActiveDateModal } from './add-active-date-modal/add-active-date-modal';
import { AddActiveDateModalComponent } from './add-active-date-modal/add-active-date-modal.component';
import { UpdateActiveDateModalComponent } from './update-active-date-modal/update-active-date-modal.component';

@Component({
  selector: 'app-scratch-card-active-times',
  templateUrl: './scratch-card-active-times.component.html',
  styleUrls: ['./scratch-card-active-times.component.css']
})
export class ScratchCardActiveTimesComponent implements OnInit {

  @Input() siteId: number;
  @Input() scratchCardId: string;
  @Input() scratchCardstartDate: any;
  @Input() scratchCardendDate: any;

  
  
  resultsMessage: string = "";
  user: AuthToken;
  showNoResultsMessage: Boolean = false;
  addActiveDateModal = {} as AddActiveDateModal;
  scratchCardActiveTime = {} as ScratchCardActiveTimesDto;
  scratchCardActiveTimes : ScratchCardActiveTimesDto[] = [];
  scratchCardActiveTimesItems: Array<any>;

  constructor(private scratchCardActiveTimesService: ScratchCardActiveTimesService,
              private dialogService : DialogService,
              private accountService: AccountService) { }

  async ngOnInit() {

    await this.loadActiveDates();   
  }

  async loadActiveDates()
  {
    this.showNoResultsMessage = false;

    this.user = this.accountService.userValue;
    this.scratchCardActiveTimes = await this.scratchCardActiveTimesService.getScratchCardActiveTimesByscratchCardId(this.siteId.toString(),this.scratchCardId);

    if (this.scratchCardActiveTimes?.length == 0) {
      this.showNoResultsMessage = true;
      this.resultsMessage = "No Scratch Card Active Times found.";
    }
  }

  async addScratchActiveDates()
  {

    this.addActiveDateModal.siteId = this.siteId.toString();
    this.scratchCardActiveTime.scratchCardUID = this.scratchCardId;
    this.addActiveDateModal.scratchCardStartDateNumber  = this.scratchCardstartDate;
    this.addActiveDateModal.scratchCardEndDateNumber  = this.scratchCardendDate;
    this.addActiveDateModal.scratchCardActiveTimesDto = this.scratchCardActiveTime;
    await this.dialogService.openReturnModalService(AddActiveDateModalComponent, `Add Active Dates `, this.addActiveDateModal , () => { });
    await this.loadActiveDates();

  }

  async editActiveDatesModal(scratchCardActiveTime : ScratchCardActiveTimesDto)
  {

    //console.log(scratchCardActiveTime)
    //return;


    this.scratchCardActiveTime = scratchCardActiveTime;
    this.addActiveDateModal.siteId = this.siteId.toString();
    this.scratchCardActiveTime.scratchCardUID = this.scratchCardId;
    //this.addActiveDateModal.scratchCardActiveTimesDto = this.scratchCardActiveTime;
    this.addActiveDateModal.statusItems = this.user?.statusItems;
    
    //this.addActiveDateModal.scratchCardEndDateNumber  = this.endDateNumber;

    this.addActiveDateModal.scratchCardStartDateNumber  = this.scratchCardstartDate;
    this.addActiveDateModal.scratchCardEndDateNumber  = this.scratchCardendDate;

    this.addActiveDateModal.scratchCardActiveTimesDto = this.scratchCardActiveTime;

    await this.dialogService.openReturnModalService(UpdateActiveDateModalComponent, `Update Active Dates `, this.addActiveDateModal , () => { });
    await this.loadActiveDates();
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.scratchCardActiveTimesItems = pageOfItems;
  }
}
