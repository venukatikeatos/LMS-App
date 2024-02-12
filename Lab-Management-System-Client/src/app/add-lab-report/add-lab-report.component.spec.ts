import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLabReportComponent } from './add-lab-report.component';

describe('AddLabReportComponent', () => {
  let component: AddLabReportComponent;
  let fixture: ComponentFixture<AddLabReportComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddLabReportComponent]
    });
    fixture = TestBed.createComponent(AddLabReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
