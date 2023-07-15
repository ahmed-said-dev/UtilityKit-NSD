import { Component, Input, OnInit } from '@angular/core';
import { Dashboard } from '../../../models/DashboardModel';
import { DashboardForm } from './dashboardForm';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder } from '@angular/forms';
import { catchError, of } from 'rxjs';
import { DashboardService } from '../../../services/dashboard.service';
import { Layout } from '../../../models/LayoutModel';
import { ToastrService } from 'ngx-toastr';
import { DataSource } from '../../../models/DataSourceModel';

const Empty_Dashboard: Dashboard = {
  id: '',
  name: '',
  description: '',
  tags: '',
  creationDate: '',
  lastModifiedDate: '',
  dataSourceId: '',
  layoutId: '',
  createdBy: '',
  lastModifiedBy: '',
};

@Component({
  selector: 'app-manage-nsd-dashboard',
  templateUrl: './manage-nsd-dashboard.component.html',
  styleUrls: ['./manage-nsd-dashboard.component.scss'],
})
export class ManageNsdDashboardComponent implements OnInit {
  @Input() editFlag: boolean;
  @Input() dashboard: Dashboard;
  dashboardForm: DashboardForm;
  layouts: Layout[] = [];
  dataSources: DataSource[] = [];
  flag = true;
  enterFlag = false;
  clicked = false;

  constructor(
    private formBuilder: FormBuilder,
    private modal: NgbActiveModal,
    private dashboardService: DashboardService,
    private notificationService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getLayouts();
    this.getDataSources();
    this.resetCurrentDashboard();
    this.intializeForm();
  }

  private resetCurrentDashboard() {
    if (!this.dashboard || !this.dashboard.id) this.dashboard = Empty_Dashboard;
  }

  private intializeForm() {
    this.dashboardForm = new DashboardForm(this.dashboard);
  }

  private getLayouts() {
    this.dashboardService.GetLayouts().subscribe((res: Layout[]) => {
      this.layouts = res;
    });
  }

  private getDataSources() {
    this.dashboardService.GetDataSources().subscribe((res: DataSource[]) => {
      this.dataSources = res;
    });
  }

  save() {
    if (this.flag) {
      this.clicked = true;
      var element = document.getElementById('myDIV');
      element?.classList.add('inprogress');
      this.flag = false;
      this.dashboard = this.dashboardForm.getFormValue();
      if (
        this.dashboard.name &&
        this.dashboard.layoutId &&
        this.dashboard.dataSourceId
      ) {
        this.enterFlag = true;
      }

      if (this.dashboard.id) this.edit();
      else this.create();
    }
  }

  private create() {
    if (this.enterFlag) {
      this.dashboard.createdBy = 'PeteMock';
      this.dashboard.lastModifiedBy = 'PeteMock';
      this.dashboardService
        .AddDashboard(this.dashboard)
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

  private edit() {
    this.dashboard.createdBy = 'PeteMock';
    this.dashboard.lastModifiedBy = 'PeteMock';
    this.dashboardService
      .UpdateDashboard(this.dashboard)
      .pipe(
        catchError((errorMessage) => {
          this.modal.dismiss();
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
  }

  public finalizeSave(res: Dashboard) {
    this.dashboard = res;
    if (this.editFlag) {
      this.notificationService.success(
        'Dashboard Is Updated Successfully',
        'Success'
      );
    } else {
      this.notificationService.success(
        'Dashboard Is Saved Successfully',
        'Success'
      );
    }
    this.close();
  }

  private close() {
    this.flag = true;
    this.modal.close(this.dashboard);
  }

  dismiss() {
    this.modal.dismiss();
  }
}
