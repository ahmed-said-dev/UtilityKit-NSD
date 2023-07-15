import { Component, Input, OnInit } from '@angular/core';
import { ConfigurationDefinition } from 'src/app/pages/models/ConfigurationDefinitionModel';
import { ConfigurationDefinitionForm } from './ConfigurationDefinitionForm';
import { FormBuilder } from '@angular/forms';
import { ConfigurationsService } from 'src/app/pages/services/configurations.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';

const Empty_ConfigurationDefinition: ConfigurationDefinition = {
  key: '',
  defaultValue: '',
  value: '',
  options: [],
  type: '',
};

@Component({
  selector: 'app-manage-configurations',
  templateUrl: './manage-configurations.component.html',
  styleUrls: ['./manage-configurations.component.scss'],
})
export class ManageConfigurationsComponent implements OnInit {
  @Input() configuration: ConfigurationDefinition;
  @Input() editFlag: boolean;
  @Input() widgetId: string;
  configurationDefinitionform: ConfigurationDefinitionForm;
  Configurations: ConfigurationDefinition[] = [];
  optionsFlag = false;
  checkFlag = false;
  flag = true;
  key: string;
  enterFlag = false;
  clicked = false;

  constructor(
    private formBuilder: FormBuilder,
    private configurationsService: ConfigurationsService,
    private modal: NgbActiveModal,
    private notificationService: ToastrService
  ) {}

  ngOnInit(): void {
    if (this.editFlag) {
      this.key = this.configuration.key;
      this.optionsFlag = this.configuration.type === 2 ? true : false;
      this.checkFlag = this.configuration.type === 3 ? true : false;
    }
    this.resetCurrentConfigurationsService();
    this.intializeForm();
    this.getConfigurations();
  }

  resetCurrentConfigurationsService() {
    if (!this.configuration || !this.configuration.key)
      this.configuration = Empty_ConfigurationDefinition;
  }

  intializeForm() {
    console.log(this.widgetId);
    this.configurationDefinitionform = new ConfigurationDefinitionForm(
      this.configuration,
      this.configurationsService,
      this.widgetId,
      this.key
    );
  }

  getConfigurations() {
    this.configurationsService.GetAll(this.widgetId).subscribe((res) => {
      this.Configurations = res.configurationDefinitions;
    });
  }

  save() {
    if (this.flag) {
      this.clicked = true;
      var element = document.getElementById('myDIV');
      element?.classList.add('inprogress');
      this.flag = false;
      this.configuration = this.configurationDefinitionform.getFormValue();
      this.configuration.type = Number(this.configuration.type);
      if (this.configuration.key && this.configuration.type) {
        this.enterFlag = true;
        this.create();
      }
    }
  }
  CheckType() {
    if (this.configurationDefinitionform.controls.type.value === '1') {
      this.optionsFlag = false;
    } else if (this.configurationDefinitionform.controls.type.value === '2') {
      this.optionsFlag = true;
    }
  }
  private create() {
    if (this.enterFlag) {
      let data: any = {};
      let c: any = {};
      if (this.editFlag)
        this.Configurations = this.Configurations.filter(
          (x) => x.key !== this.key
        );
      this.configuration.defaultValue = this.configuration.value;
      c = {
        key: this.configuration.key,
        value: this.configuration.value,
        defaultValue: this.configuration.defaultValue,
        options: this.configuration.options,
        type: this.configuration.type,
      };
      this.Configurations.push(c);
      data = {
        configurationDefinitions: this.Configurations,
      };
      this.configurationsService
        .UpdateWidgetWithConfigurations(this.widgetId, data)
        .pipe(
          catchError((errorMessage) => {
            var msg = errorMessage?.error?.Message ?? 'server error';
            this.notificationService.error(msg, 'Error');
            return of(errorMessage);
          })
        )
        .subscribe({
          next: (response) => {
            if (response.error) return;
            this.finalizeSave(response);
          },
        });
    } else {
      this.flag = true;
      this.clicked = false;
    }
  }

  public finalizeSave(res: ConfigurationDefinition) {
    if (this.editFlag) {
      this.notificationService.success(
        'Configuration Definition Is Updated Successfully',
        'Success'
      );
    } else {
      this.notificationService.success(
        'Configuration Definition Is Saved Successfully',
        'Success'
      );
    }
    this.close();
  }

  private close() {
    this.flag = true;
    let c: any = {};
    c = {
      key: this.configuration.key,
      value: this.configuration.value,
      defaultValue: this.configuration.defaultValue,
      options: this.configuration.options,
      type: this.configuration.type,
      oldKey: this.key,
    };
    this.modal.close(c);
  }

  dismiss() {
    this.modal.dismiss();
  }
}
