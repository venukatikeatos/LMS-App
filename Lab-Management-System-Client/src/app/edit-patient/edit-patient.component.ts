import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientsService } from '../sevrices/patients.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css'],
})
export class EditPatientComponent implements OnInit {
  patientForm: FormGroup;
  patientId: any;
  response: any;

  constructor(
    private route: ActivatedRoute,
    private patientService: PatientsService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.patientForm = this.fb.group({
      patientID: [''],
      patientName: [''],
      patientAddress: [''],
      patientGender: [''],
      patientAge: [''],
      patientDOB: [''],
    });
  }

  ngOnInit() {
    this.patientId = this.route.snapshot.paramMap.get('id');
    this.patientService.getPatientById(this.patientId).subscribe((res: any) => {
      console.log(res);
      this.response = res;

      console.log(this.patientForm);
      this.populateForm();
    });
  }
  populateForm() {
    this.patientForm.patchValue({
      patientID: this.response.patientID,
      patientName: this.response.patientName,
      patientAddress: this.response.patientAddress,
      patientGender: this.response.patientGender,
      patientAge: this.response.patientAge,
      patientDOB: this.response.patientDOB,
    });
  }

  updatePatient() {
    if (this.patientForm.valid) {
      const updatedPatientData = this.patientForm.value;

      // Send PUT request to update patient data
      this.patientService
        .UpdatePatient(updatedPatientData, this.patientId)
        .subscribe((res) => {
          console.log(res);
        });
      alert('Record modified Successfully');
      this.router.navigate(['/Patients']);
    } else {
      alert('please fill all the Feilds');
    }
  }
}
