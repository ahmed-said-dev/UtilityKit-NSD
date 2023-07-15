import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Dashboard, LayoutCell } from '../models/DashboardModel';
import { DataSource } from '../models/DataSourceModel';
import { Layout } from '../models/LayoutModel';

@Injectable({
  providedIn: 'root',
})
export class LayoutCellService {
  public readonly LayoutCellApi = `${environment.api_Testing_Url}LayoutCell`;
  constructor(private http: HttpClient) {}

  Update(layoutCell: LayoutCell): Observable<LayoutCell> {
    return this.http.patch<LayoutCell>(`${this.LayoutCellApi}`, layoutCell);
  }
}
