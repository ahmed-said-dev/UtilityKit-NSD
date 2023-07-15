import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Dashboard } from '../../../models/DashboardModel';

export class DashboardForm extends FormGroup {
  constructor(
    readonly model: Dashboard,
    readonly fb: FormBuilder = new FormBuilder()
  ) {
    super(
      fb.group({
        id: [model?.id],
        name: [
          model?.name,
          [
            Validators.required,
            //Validators.pattern(/^(\s+\S+\s*)*(?!\s).*$/),
            Validators.maxLength(100),
          ],
        ],
        tags: [model?.tags, [Validators.maxLength(500)]],
        description: [model?.description, [Validators.maxLength(500)]],
        creationDate: [model?.creationDate],
        lastModifiedDate: [model?.lastModifiedDate],
        dataSourceId: [model?.dataSourceId, [Validators.required]],
        layoutId: [model?.layoutId, [Validators.required]],
      }).controls
    );
  }

  getFormValue(): Dashboard {
    var model = new Dashboard();
    if (this.valid) {
      model.id = this.controls.id.value;
      model.name = this.controls.name.value;
      model.description = this.controls.description.value;
      model.tags = this.controls.tags.value;
      model.creationDate = this.controls.creationDate.value;
      model.lastModifiedDate = this.controls.lastModifiedDate.value;
      model.dataSourceId = this.controls.dataSourceId.value;
      model.layoutId = this.controls.layoutId.value;
    }
    return model;
  }
}
