import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LabReportsService } from '../sevrices/lab-reports.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-lab-report',
  templateUrl: './add-lab-report.component.html',
  styleUrls: ['./add-lab-report.component.css']
})
export class AddLabReportComponent implements OnInit {
  labReportForm:any;

  constructor(private labReportServices:LabReportsService,private fb:FormBuilder,private router: Router) {
    
  }
    ngOnInit(): void {
      this.createForm();
      
    }
  
  
  
  createForm() {
    this.labReportForm = this.fb.group({
      patientID: ['', Validators.required],
      patientName: ['', Validators.required],
      testType: ['', Validators.required],
      enteredTime: ['', Validators.required],
      timeofTest: ['', Validators.required],
      results: ['', Validators.required]
    });
  }

  
  onSubmit(){
    if (this.labReportForm.valid) {
       const labReportData = this.labReportForm.value;
       if(labReportData != null ){
         this.labReportServices.AddLabReports(labReportData).subscribe((results)=>
         {
            alert("Successfully added")
        }
        )
        this.router.navigate(["/LabReports"])
      }
     
  }
  else{
    alert("Please Provide Correct Data")
  }
  }
}
