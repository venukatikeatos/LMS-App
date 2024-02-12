import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LabReportsComponent } from './lab-reports.component';

describe('LabReportsComponent', () => {
  let component: LabReportsComponent;
  let fixture: ComponentFixture<LabReportsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LabReportsComponent]
    });
    fixture = TestBed.createComponent(LabReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
