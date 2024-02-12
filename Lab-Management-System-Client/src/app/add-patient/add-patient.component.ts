import { Component, OnInit } from '@angular/core';
import { PatientsService } from '../sevrices/patients.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LabReportsService } from '../sevrices/lab-reports.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css'],
})
export class AddPatientComponent implements OnInit {
  patientForm: any;

  constructor(
    private patientsService: PatientsService,
    private fb: FormBuilder,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.patientForm = this.fb.group({
      patientName: ['', Validators.required],
      patientAddress: ['', Validators.required],
      patientGender: ['', Validators.required],
      patientAge: ['', Validators.required],
      patientDOB: ['', Validators.required],
    });
  }


  onSubmit() {
    if (this.patientForm.valid) {
      const patientData = this.patientForm.value;
      this.patientsService.AddPatient(patientData).subscribe((results) => {
        console.warn(results);
      });
      alert('Successfully Created Patiaent Details');
      this.router.navigate(['/Patients']);
    } else {
      alert('please fill the all feilds');
    }
  }
}
