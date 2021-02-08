import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-edit-logs',
  templateUrl: './edit-logs.component.html',
  styleUrls: ['./edit-logs.component.scss']
})
export class EditLogsComponent implements OnInit {

  logsForm: FormGroup;
  id: number = null;
  sourceIP = '';
  channel = '';
  userName = '';
  created: Date = null;
  method = '';
  url = '';
  httpVersion = '';
  httpCode: number = null;
  port: number = null;
  urlDestination = '';
  browserAgent = '';
  
  isLoadingResults = false;
  matcher = new MyErrorStateMatcher();

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getLogsById(this.route.snapshot.params.id);
    this.logsForm = this.formBuilder.group({
      sourceIP : [null],
      channel : [null],
      userName : [null],
      created : [null],
      method : [null, Validators.required],
      url : [null, Validators.required],
      httpVersion : [null, Validators.required],
      httpCode : [null, Validators.required],
      port : [null],
      urlDestination : [null, Validators.required],
      browserAgent : [null]
    });
  }

  getLogsById(id: any) {
    this.api.getLogsById(id).subscribe((data: any) => {
      this.id = data.id;
      this.logsForm.setValue({
        sourceIP: data.sourceIP,
        channel: data.channel,
        userName: data.userName,
        created: data.created,
        method: data.method,
        url: data.url,
        httpVersion: data.httpVersion,
        httpCode: data.httpCode,
        port: data.port,
        urlDestination: data.urlDestination,
        browserAgent: data.browserAgent,
      });
    });
  }

  onFormSubmit() {
    this.isLoadingResults = true;
    this.api.addLogs(this.logsForm.value)
      .subscribe((res: any) => {
          const id = res.id;
          this.isLoadingResults = false;
          this.router.navigate(['/logs-details', id]);
        }, (err: any) => {
          console.log(err);
          this.isLoadingResults = false;
        });
  }

  logsDetails() {
    this.router.navigate(['/logs-details', this.id]);
  }
}
