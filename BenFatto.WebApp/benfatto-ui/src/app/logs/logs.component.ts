import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Logs } from '../logs';

@Component({
  selector: 'app-logs',
  templateUrl: './logs.component.html',
  styleUrls: ['./logs.component.scss']
})
export class LogsComponent implements OnInit {

  displayedColumns: string[] = ['sourceIP', 'userName', 'url', 'created', 'method', 'httpCode' ];
  data: Logs[] = [];
  isLoadingResults = true;

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.getLogs()
    .subscribe((res: any) => {
      this.data = res;
      console.log(this.data);
      this.isLoadingResults = false;
    }, err => {
      console.log(err);
      this.isLoadingResults = false;
    });
  }

}
