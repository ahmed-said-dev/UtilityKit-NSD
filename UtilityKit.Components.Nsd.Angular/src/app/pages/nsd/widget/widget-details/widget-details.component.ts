import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManageConfigurationsComponent } from './manage-configurations/manage-configurations.component';
import { ManageWidgetGalleryComponent } from './manage-widget-gallery/manage-widget-gallery.component';
import { WidgetService } from '../WidgetServies/widget.service';
import { Industry, WidgetModel } from '../WidgetModel/widget-model';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ConfigurationDefinition } from 'src/app/pages/models/ConfigurationDefinitionModel';
import { ConfigurationsService } from 'src/app/pages/services/configurations.service';
import { SwalService } from 'src/app/shared/services/Swal.service';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'app-widget-details',
  templateUrl: './widget-details.component.html',
  styleUrls: ['./widget-details.component.scss'],
})
export class WidgetDetailsComponent implements OnInit {
  ndustryEnum = Industry;
  WidgetData: WidgetModel;
  id: any;
  Configurations: ConfigurationDefinition[] = [];
  flag: boolean = false;

  constructor(
    private cdr: ChangeDetectorRef,
    private route: ActivatedRoute,
    private widgetservies: WidgetService,
    private modalService: NgbModal,
    private spinnerService: NgxSpinnerService,
    private configurationsService: ConfigurationsService,
    private notificationService: ToastrService,
    private swalService: SwalService
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getConfigurations();
    //#region Get Id From Url && Calling Api
    this.widgetservies.GetById(this.id).subscribe({
      next: (Date) => {
        this.WidgetData = Date.widgetDetailes;
        console.log(this.WidgetData);
        this.cdr.detectChanges();
      },
      error: (Erro) => {
        console.log(Erro);
      },
    });
  }

  getConfigurations() {
    this.spinnerService.show();
    this.configurationsService.GetAll(this.id).subscribe((res) => {
      if (res.configurationDefinitions !== null) {
        this.Configurations = res.configurationDefinitions;
        if (this.Configurations.length === 0) {
          this.flag = true;
        }
        this.cdr.detectChanges();
        this.spinnerService.hide();
      } else {
        this.flag = true;
        this.cdr.detectChanges();
      }
    });
  }

  onEdit(item: ConfigurationDefinition) {
    var ConfigurationModal = this.modalService.open(
      ManageConfigurationsComponent
    );
    ConfigurationModal.componentInstance.configuration = item;
    ConfigurationModal.componentInstance.editFlag = true;
    ConfigurationModal.componentInstance.widgetId = this.id;

    ConfigurationModal.result.then((val) => {
      if (val) {
        var i = this.Configurations.findIndex((x) => x.key == val.oldKey);
        this.Configurations[i].key = val.key;
        this.Configurations[i].type = val.type;
        this.Configurations[i].value = val.value;
        this.Configurations[i].defaultValue = val.defaultValue;
        this.Configurations[i].options = val.options;
        this.cdr.detectChanges();

        //this.Configurations.unshift(this.Configurations.pop()!);
        //this.cdr.detectChanges();

        //this.Configurations.unshift(this.Configurations.pop()!);
      }
    });
  }

  onDelete(item: ConfigurationDefinition) {
    let data: any = {};
    this.swalService.deleteConfirmation(item.key ?? '', () => {
      data = {
        configurationDefinitions: this.Configurations.filter(
          (x) => x.key !== item.key
        ),
      };
      this.configurationsService
        .UpdateWidgetWithConfigurations(this.id, data)
        .pipe(
          catchError((errorMessage) => {
            var msg = errorMessage?.error?.Message;
            this.notificationService.error(msg, 'Error');
            return of(errorMessage);
          })
        )
        .subscribe((res) => {
          if (res.error) return;
          this.getConfigurations();
          this.notificationService.success(
            `(${item.key}) Is Deleted Successfully`,
            'Success'
          );
        });
    });
  }

  openManageConfigurations() {
    var ConfigurationModal = this.modalService.open(
      ManageConfigurationsComponent
    );
    ConfigurationModal.componentInstance.widgetId = this.id;

    ConfigurationModal.result.then((val) => {
      if (val) {
        this.Configurations.splice(0, 0, val);
        this.cdr.detectChanges();
      }
    });
  }

  openManageWidgetGallery() {
    this.modalService.open(ManageWidgetGalleryComponent, { size: 'lg' });
  }
}
