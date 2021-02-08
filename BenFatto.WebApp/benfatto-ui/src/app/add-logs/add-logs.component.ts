import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  selector: 'app-add-logs',
  templateUrl: './add-logs.component.html',
  styleUrls: ['./add-logs.component.scss']
})
export class AddLogsComponent implements OnInit {
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

  constructor(private router: Router, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.logsForm = this.formBuilder.group({
      sourceIP : [null],
      channel : [null],
      userName : [null],
      method : [null, Validators.required],
      url : [null, Validators.required],
      httpVersion : [null],
      httpCode : [null, Validators.required],
      port : [null],
      urlDestination : [null, Validators.required],
      browserAgent : [null]
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
}
