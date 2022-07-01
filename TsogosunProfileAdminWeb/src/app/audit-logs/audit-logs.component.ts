import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LogFilesDto } from '../model/Dtos/profile-admin/logFilesDto';
import { AuditLogsService } from '../service/profile-admin/audit-logs-service';
import { DialogService } from '../shared/dialog/dialog.service';
import { ClearLogsComponent } from './clear-logs/clear-logs.component';

@Component({
  selector: 'app-audit-logs',
  templateUrl: './audit-logs.component.html',
  styleUrls: ['./audit-logs.component.css']
})
export class AuditLogsComponent implements OnInit {

  logFilesDto: LogFilesDto[] = [];
  logFilesDtoItems: Array<any>;
  showNoResultsMessage : Boolean = false;
  resultsMessage: string  = "";

  constructor(private auditLogsService: AuditLogsService,
              public dialogService: DialogService,
              private router: Router) { }


  async ngOnInit() {
    await this.loadLogFiles();
  }

  async loadLogFiles()
  {
    this.showNoResultsMessage = false;
    this.logFilesDto = await this.auditLogsService.getLogFiles();
    if(this.logFilesDto?.length == 0)
    {
        this.showNoResultsMessage = true;
        this.resultsMessage = "No results found.";
    } 
  }

  goToLink(url: string) {
    window.open(url, "_blank");
  }

  async deleteLogFiles()
  {
    await this.dialogService.openReturnModalService(ClearLogsComponent, `Clear log files `, null, () => { });
    await this.loadLogFiles();
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.logFilesDtoItems = pageOfItems;
  }
}
