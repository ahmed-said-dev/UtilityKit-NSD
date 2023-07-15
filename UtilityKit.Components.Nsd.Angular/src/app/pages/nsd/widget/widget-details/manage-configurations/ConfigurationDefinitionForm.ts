import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfigurationDefinition } from 'src/app/pages/models/ConfigurationDefinitionModel';
import { ConfigurationsService } from 'src/app/pages/services/configurations.service';
import { UniqueConfigurationDefinitionKeyValidator } from 'src/app/pages/validators/UniqueConfigurationDefinitionKeyValidator';

export class ConfigurationDefinitionForm extends FormGroup {
  constructor(
    readonly model: ConfigurationDefinition,
    private configurationsService: ConfigurationsService,
    readonly widgetId: string,
    readonly oldKey?: string | undefined,
    readonly fb: FormBuilder = new FormBuilder()
  ) {
    super(
      fb.group({
        key: [
          model?.key,
          [Validators.required, Validators.maxLength(100)],
          [
            UniqueConfigurationDefinitionKeyValidator.createValidator(
              configurationsService,
              widgetId,
              oldKey ? oldKey : ''
            ),
          ],
        ],
        value: [model?.value],
        type: [model?.type, [Validators.required]],
        options: [model?.options],
      }).controls
    );
  }

  getFormValue(): ConfigurationDefinition {
    var model = new ConfigurationDefinition();
    if (this.valid) {
      model.key = this.controls.key.value;
      model.value = this.controls.value.value;
      model.type = this.controls.type.value;
      if (Array.isArray(this.controls.options.value))
        model.options = this.controls.options.value;
      else model.options = this.controls.options.value.split(',');
    }
    return model;
  }
}
