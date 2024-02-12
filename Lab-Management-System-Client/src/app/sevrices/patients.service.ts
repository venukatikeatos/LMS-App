import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientsService {

  url='https://localhost:7239/Patient';
  v: any;
  
  constructor(private http:HttpClient) 
  {
    
  }
    patients():Observable<any>
      {
        return this.http.get(this.url);
      }
      getPatientById(pId:any):Observable<any>
      {
        return this.http.get(this.url+"/"+ pId);
      }

      postpatients(patientData: any): Observable<any> {
        return this.http.post(this.url, patientData);
      }
      DeletePatiet(id:any):Observable<any>{

        return this.http.delete(this.url+"?id="+id);
      }
      AddPatient(labReportData: any):Observable<any>{

        return this.http.post(this.url,labReportData);
      }
      UpdatePatient(response:object,patientID:any):Observable<any>{

      //  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      //  console.log("its"+headers)
      
        this.v = this.http.put(this.url+"/"+patientID+"/edit",response);
        return this.v;
      }
}
