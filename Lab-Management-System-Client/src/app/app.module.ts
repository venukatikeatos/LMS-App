import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { LabReportsComponent } from './lab-reports/lab-reports.component';
import { PatientsComponent } from './patients/patients.component';
import { PatientsService } from './sevrices/patients.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { AddLabReportComponent } from './add-lab-report/add-lab-report.component';
import { EditPatientComponent } from './edit-patient/edit-patient.component';
import { EditLabReportComponent } from './edit-lab-report/edit-lab-report.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LabReportsComponent,
    PatientsComponent,
    AddPatientComponent,
    AddLabReportComponent,
    EditPatientComponent,
    EditLabReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [PatientsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
