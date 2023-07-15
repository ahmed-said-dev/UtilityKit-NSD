import { Injectable } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  ValidationErrors,
} from '@angular/forms';
import { map, Observable } from 'rxjs';
import { ConfigurationsService } from '../services/configurations.service';

@Injectable({ providedIn: 'root' })
export class UniqueConfigurationDefinitionKeyValidator {
  static createValidator(
    configurationsService: ConfigurationsService,
    widgetId: string,
    oldKey: string | undefined
  ): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return configurationsService
        .IsConfigurationDefinitionKeyUnique(control.value, widgetId, oldKey)
        .pipe(map((result: boolean) => (result ? { nameExists: true } : null)));
    };
  }
}
