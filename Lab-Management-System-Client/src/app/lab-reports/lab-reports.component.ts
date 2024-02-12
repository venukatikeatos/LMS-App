import { Component } from '@angular/core';
import { LabReportsService } from '../sevrices/lab-reports.service';

@Component({
  selector: 'app-lab-reports',
  templateUrl: './lab-reports.component.html',
  styleUrls: ['./lab-reports.component.css']
})
export class LabReportsComponent {
  labReportData: any;
  /**
   *
   */
  constructor(private labReportService: LabReportsService) {
    
  }
  ngOnInit(): void {
    this.getLabReports();
  }

  getLabReports(){
    this.labReportService.labReports().subscribe((data) =>{
      console.log('data',data);
      this.labReportData = data;

    })  }
  DeleteLabReport(ID:any){
      this.labReportService.DeleteLabReports(ID).subscribe(data=>{})
       alert("Do you really want to Deleted?");    
       this.getLabReports();  

    }
  // AddLabReport(ID:any){
  //   this.labReportService.
  // }

    
 
}