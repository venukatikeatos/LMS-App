import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLabReportComponent } from './edit-lab-report.component';

describe('EditLabReportComponent', () => {
  let component: EditLabReportComponent;
  let fixture: ComponentFixture<EditLabReportComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditLabReportComponent],
    });
    fixture = TestBed.createComponent(EditLabReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
