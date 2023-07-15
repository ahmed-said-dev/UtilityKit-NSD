import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Dashboard } from '../models/DashboardModel';
import { DataSource } from '../models/DataSourceModel';
import { Layout } from '../models/LayoutModel';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  public readonly dashboardApi = `${environment.api_Testing_Url}Dashboard`;
  constructor(private http: HttpClient) {}

  AddDashboard(dashboard: Dashboard): Observable<Dashboard> {
    return this.http.post<Dashboard>(`${this.dashboardApi}`, dashboard);
  }

  UpdateDashboard(dashboard: Dashboard): Observable<Dashboard> {
    return this.http.patch<Dashboard>(`${this.dashboardApi}`, dashboard);
  }

  GetAll(): Observable<Dashboard[]> {
    return this.http.get<Dashboard[]>(`${this.dashboardApi}`);
  }

  Get(Id: string): Observable<Dashboard> {
    return this.http.get<Dashboard>(`${this.dashboardApi}/Dashboard?Id=${Id}`);
  }

  Delete(Id: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.dashboardApi}?Id=${Id}`);
  }

  GetLayouts(): Observable<Layout[]> {
    return this.http.get<Layout[]>(`${this.dashboardApi}/layout`).pipe(
      map((response: Layout[]) => {
        return response;
      })
    );
  }

  GetDataSources(): Observable<DataSource[]> {
    return this.http.get<DataSource[]>(`${this.dashboardApi}/dataSource`).pipe(
      map((response: DataSource[]) => {
        return response;
      })
    );
  }
}
