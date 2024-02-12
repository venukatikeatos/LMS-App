import { Component, OnInit } from '@angular/core';
import { PatientsService } from '../sevrices/patients.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})
export class PatientsComponent implements OnInit {
    patientsData:any;
  
    constructor(private patientsService: PatientsService,private router : Router) { }
  
    ngOnInit(): void {
      this.getPatients();
      
    }

    getPatients(){
      this.patientsService.patients().subscribe((data) =>{
        console.log('data',data);
        this.patientsData = data;

      })
    }
    DeletePatient(ID:any){
      this.patientsService.DeletePatiet(ID).subscribe(data=>{
        })
        alert("Patient Deleted Successfully");
        this.getPatients();


      }



}
