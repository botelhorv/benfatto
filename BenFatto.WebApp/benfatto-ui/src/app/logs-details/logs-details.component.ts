import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';
import { Logs } from '../logs';

@Component({
  selector: 'app-logs-details',
  templateUrl: './logs-details.component.html',
  styleUrls: ['./logs-details.component.scss']
})
export class LogsDetailsComponent implements OnInit {

  logs: Logs = { id: null, sourceIP: '', channel: '', userName: '', created: null, method: '', url: '', httpVersion: '', httpCode: null, port: null, urlDestination: '', browserAgent: '' };
  isLoadingResults = true;

  constructor(private route: ActivatedRoute, private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getLogsDetails(this.route.snapshot.params.id);
  }

  getLogsDetails(id: number) {
    this.api.getLogsById(id)
      .subscribe((data: any) => {
        this.logs = data;
        console.log(this.logs);
        this.isLoadingResults = false;
      });
  }

  deleteLogs(id: any) {
    this.isLoadingResults = true;
    this.api.deleteLogs(id)
      .subscribe(res => {
          this.isLoadingResults = false;
          this.router.navigate(['/logs']);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        }
      );
  }

}
