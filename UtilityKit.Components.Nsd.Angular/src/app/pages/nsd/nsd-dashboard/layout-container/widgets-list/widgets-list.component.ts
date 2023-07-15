import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { WidgetService } from '../../../widget/WidgetServies/widget.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { WidgetModel } from '../../../widget/WidgetModel/widget-model';
import { FormControl } from '@angular/forms';
import { LayoutCell } from 'src/app/pages/models/DashboardModel';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
import { LayoutCellService } from 'src/app/pages/services/layoutCell.service';

@Component({
  selector: 'app-widgets-list',
  templateUrl: './widgets-list.component.html',
  styleUrls: ['./widgets-list.component.scss'],
})
export class WidgetsListComponent implements OnInit {
  @Input() cell: LayoutCell;
  public widgets: WidgetModel[];
  widgetId = new FormControl('');
  flag = true;
  enterFlag = false;
  clicked = false;

  constructor(
    private modalService: NgbModal,
    private modal: NgbActiveModal,
    private layoutCellService: LayoutCellService,
    private notificationService: ToastrService,
    private cdr: ChangeDetectorRef,
    private widgetService: WidgetService
  ) {}

  ngOnInit(): void {
    this.getWidgets();
  }

  save() {
    if (this.flag) {
      this.clicked = true;
      var element = document.getElementById('myDIV');
      element?.classList.add('inprogress');
      this.flag = false;
      if (this.widgetId.value) {
        this.cell.widgetId = this.widgetId.value;
        this.enterFlag = true;
      }
      this.update();
    }
  }
  update() {
    if (this.enterFlag) {
      this.layoutCellService
        .Update(this.cell)
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
  getWidgets() {
    this.widgetService.GetAll().subscribe((res: any) => {
      this.widgets = res.getWidgetDtos;
      // this.widgets = this.widgets.filter(
      //   (x) => x.minCellSize <= this.cell.cellSize
      // );
      this.cdr.detectChanges();
    });
  }
  public finalizeSave(res: any) {
    this.cell = res;

    this.notificationService.success(
      'Widget Is Added To Layout Cell Successfully',
      'Success'
    );

    this.close();
  }

  private close() {
    this.flag = true;
    this.modal.close(this.cell);
  }

  dismiss() {
    this.modal.dismiss();
  }
}
