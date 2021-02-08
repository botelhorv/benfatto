import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportLogsComponent } from './import-logs.component';

describe('ImportLogsComponent', () => {
  let component: ImportLogsComponent;
  let fixture: ComponentFixture<ImportLogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportLogsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportLogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
