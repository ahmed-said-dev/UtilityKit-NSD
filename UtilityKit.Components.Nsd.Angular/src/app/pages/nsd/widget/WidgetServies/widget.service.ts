import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WidgetService {
  public readonly WidgetApi = `${environment.api_Testing_Url}Widget`;
  constructor(private http: HttpClient) {}

  GetAll(): Observable<any> {
    return this.http.get<any>(`${this.WidgetApi}`);
  }
  GetById(id:any): Observable<any> {
    return this.http.get<any>(`${this.WidgetApi}/Id?id=`+id);
  }
}
