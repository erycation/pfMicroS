import { Component, OnInit } from '@angular/core';
import { AuditLogsService } from 'src/app/service/profile-admin/audit-logs-service';

@Component({
  selector: 'app-clear-logs',
  templateUrl: './clear-logs.component.html',
  styleUrls: ['./clear-logs.component.css']
})
export class ClearLogsComponent implements OnInit {

  logsMessage : string;
  historyDate: Date;

  constructor(private auditLogsService: AuditLogsService) { }

  ngOnInit(): void {

    var startDateConfig = new Date();
    startDateConfig.setDate(startDateConfig.getDate() - 30);
    this.historyDate = startDateConfig;
    this.logsMessage = `Delete History Before ${this.historyDate.toISOString().slice(0, 10)}`;
  }

  async clearLogsFiles()
  {
    (await this.auditLogsService.clearLogFiles()).subscribe(result => {
     
    },
      error => {
        
      });
  }
}
