import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PatientsComponent } from './patients/patients.component';
import { LabReportsComponent } from './lab-reports/lab-reports.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { AddLabReportComponent } from './add-lab-report/add-lab-report.component';
import { EditPatientComponent } from './edit-patient/edit-patient.component';
import { EditLabReportComponent } from './edit-lab-report/edit-lab-report.component';



const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'LabReports',component:LabReportsComponent},
  {path:'Patients', component:PatientsComponent},
  {path:'AddPatient', component:AddPatientComponent},
  {path:'AddLabReport', component:AddLabReportComponent},
  {path:'AddPatient/:id/edit', component:EditPatientComponent},
  {path:'AddLabReport/:id/edit', component:EditLabReportComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
  RouterModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
