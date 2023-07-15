import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DrillDownChartService {

  constructor(private myClient:HttpClient) { }
    //URL
    private Base_URL = "https://localhost:7001/api/Chart/transformedData";
    private Details_URL = "https://localhost:7001/api/Chart/alldata";
  

    // Get Chart Data
    getTransformedData(){
      return this.myClient.get(this.Base_URL);
    }
    getChartsDetails(){
      return this.myClient.get(this.Details_URL);
    }


}
