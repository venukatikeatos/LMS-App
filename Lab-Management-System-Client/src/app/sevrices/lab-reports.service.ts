import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LabReportsService {

  url='https://localhost:7239/LabReport';
  v: any;
  
  constructor(private http:HttpClient) 
  {
    
  }
    labReports():Observable<any>
      {
        return this.http.get(this.url);
      }
      getlabReportById(lRId:any):Observable<any>
      {
        return this.http.get(this.url+"/"+ lRId);
      }
      DeleteLabReports(id:any):Observable<any>{

        return this.http.delete(this.url+"?id="+id);
      }
      AddLabReports(labReportData: any):Observable<any>{

        return this.http.post(this.url,labReportData);
      }

      updateLabReporvt(labReportData: any):Observable<any>{

        return this.http.put(this.url,labReportData);
      }
      updateLabReports(response:object,reportID:any):Observable<any>{

        //  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        //  console.log("its"+headers)
        
          this.v = this.http.put(this.url+"/"+reportID+"/edit",response);
          return this.v;
        }

}
