import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ConfigurationDefinition } from '../models/ConfigurationDefinitionModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ConfigurationsService {
  public readonly ConfigurationsApi = `${environment.api_Testing_Url}ConfigurationDefinition`;
  constructor(private http: HttpClient) {}

  UpdateWidgetWithConfigurations(
    widgetId: string,
    configurations: any
  ): Observable<any> {
    return this.http.post<any>(
      `${this.ConfigurationsApi}?widgetId=${widgetId}`,
      configurations
    );
  }

  GetAll(widgetId: string): Observable<any> {
    return this.http.get<any>(`${this.ConfigurationsApi}?widgetId=${widgetId}`);
  }

  public IsConfigurationDefinitionKeyUnique(
    key: string,
    widgetId: string,
    oldKey: string | undefined
  ): Observable<boolean> {
    if (oldKey) {
      return this.http.get<boolean>(
        `${this.ConfigurationsApi}/key?key=${key}&widgetId=${widgetId}&oldKey=${oldKey}`
      );
    } else {
      return this.http.get<boolean>(
        `${this.ConfigurationsApi}/key?key=${key}&widgetId=${widgetId}`
      );
    }
  }
}
