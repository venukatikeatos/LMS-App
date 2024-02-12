import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LabReportsService } from '../sevrices/lab-reports.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-lab-report',
  templateUrl: './edit-lab-report.component.html',
  styleUrls: ['./edit-lab-report.component.css'],
})
export class EditLabReportComponent implements OnInit {
  labReportForm: FormGroup;
  reportId: any;
  response: any;

  constructor(
    private route: ActivatedRoute,
    private labReportService: LabReportsService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.labReportForm = this.fb.group({
      reportID: ['', Validators.required],
      patientID: ['', Validators.required],
      patientName: ['', Validators.required],
      testType: ['', Validators.required],
      enteredTime: ['', Validators.required],
      timeofTest: ['', Validators.required],
      results: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.reportId = this.route.snapshot.paramMap.get('id');
    this.labReportService
      .getlabReportById(this.reportId)
      .subscribe((res: any) => {
        console.log(res);

        this.response = res;

        console.log(this.labReportForm);
        this.populateForm();
      });
  }

  populateForm() {
    this.labReportForm.patchValue({
      reportID: this.response.reportID,
      patientID: this.response.patientID,
      patientName: this.response.patientName,
      testType: this.response.testType,
      enteredTime: this.response.enteredTime,
      timeofTest: this.response.timeofTest,
      results: this.response.results,
    });
  }

  updateLabReport() {
    if (this.labReportForm.valid) {
      const updatedlabReportData: any = this.labReportForm.value;

      // Send PUT request to update patient data
      this.labReportService
        .updateLabReports(updatedlabReportData, updatedlabReportData.reportID)
        .subscribe((res) => {
          console.log(res);
          alert('Success');
        });

      this.router.navigate(['/LabReports']);
    } else {
      alert('Please Fill the all Feilds');
    }
  }
}
