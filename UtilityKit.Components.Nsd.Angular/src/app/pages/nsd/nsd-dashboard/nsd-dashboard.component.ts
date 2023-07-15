import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManageNsdDashboardComponent } from './manage-nsd-dashboard/manage-nsd-dashboard.component';
import { SwalService } from 'src/app/shared/services/Swal.service';
import { DashboardService } from '../../services/dashboard.service';
import { Dashboard } from '../../models/DashboardModel';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Layout } from '../../models/LayoutModel';

@Component({
  selector: 'app-nsd-dashboard',
  templateUrl: './nsd-dashboard.component.html',
  styleUrls: ['./nsd-dashboard.component.scss'],
})
export class NsdDashboardComponent implements OnInit {
  Dashboards: Dashboard[] = [];
  layouts: Layout[] = [];
  flag: boolean = false;

  constructor(
    private modalService: NgbModal,
    private cdr: ChangeDetectorRef,
    private notificationService: ToastrService,
    private dashboardService: DashboardService,
    private router: Router,
    private route: ActivatedRoute,
    private spinnerService: NgxSpinnerService,
    private swalService: SwalService
  ) {}

  ngOnInit(): void {
    this.getLayouts();
    this.getDashboards();
  }

  getLayouts() {
    this.dashboardService.GetLayouts().subscribe((res: Layout[]) => {
      this.layouts = res;
    });
  }

  getDashboards() {
    this.spinnerService.show();
    this.dashboardService.GetAll().subscribe((res: Dashboard[]) => {
      this.Dashboards = res;
      if (this.Dashboards.length === 0) {
        this.flag = true;
      }
      this.cdr.detectChanges();
      this.spinnerService.hide();
    });
  }

  openManageDashboard() {
    var DashboardModal = this.modalService.open(ManageNsdDashboardComponent);
    DashboardModal.componentInstance.editFlag = false;

    DashboardModal.result.then((val) => {
      if (val) {
        this.Dashboards.splice(0, 0, val);
        this.cdr.detectChanges();
      }
    });
  }

  onEdit(item: Dashboard) {
    var DashboardModal = this.modalService.open(ManageNsdDashboardComponent);
    DashboardModal.componentInstance.dashboard = item;
    DashboardModal.componentInstance.editFlag = true;

    DashboardModal.result.then((val) => {
      if (val) {
        this.getDashboards();
      }
    });
  }

  onDelete(item: Dashboard) {
    this.swalService.deleteConfirmation(item.name ?? '', () => {
      this.dashboardService
        .Delete(item.id)
        .pipe(
          catchError((errorMessage) => {
            var msg = errorMessage?.error?.Message;
            this.notificationService.error(msg, 'Error');
            return of(errorMessage);
          })
        )
        .subscribe((res) => {
          if (res.error) return;
          this.getDashboards();
          this.notificationService.success(
            `(${item.name}) Is Deleted Successfully`,
            'Success'
          );
        });
    });
  }
}
