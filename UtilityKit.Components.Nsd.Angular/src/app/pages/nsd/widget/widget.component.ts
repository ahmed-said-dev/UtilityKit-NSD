import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManageWidgetGalleryComponent } from './widget-details/manage-widget-gallery/manage-widget-gallery.component';
import { ManageConfigurationsComponent } from './widget-details/manage-configurations/manage-configurations.component';
import { Router } from '@angular/router';
import { WidgetModel } from './WidgetModel/widget-model';
import { MenuComponent } from 'src/app/_metronic/kt/components';
import { WidgetService } from './WidgetServies/widget.service';

@Component({
  selector: 'app-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.scss'],
})
export class WidgetComponent implements OnInit {
  constructor(
    private modalService: NgbModal,
    private cdr: ChangeDetectorRef,
    private router: Router,
    private widget_Servies: WidgetService
  ) {}
  public WidgetsData: WidgetModel[];

  ngOnInit(): void {
    this.widget_Servies.GetAll().subscribe({
      next: (Date) => {
        this.WidgetsData = Date.getWidgetDtos;
        console.log(this.WidgetsData)
        this.cdr.detectChanges();
        this.menuReinitialization();
      },
      error: (Erro) => {
        console.log(Erro);
      },
    });
  }

  openManageConfigurations() {
    this.modalService.open(ManageConfigurationsComponent);
  }
  onDetails(widgetid:any) {
    this.router.navigate([`/nsd/widget/details/`,widgetid]);
  }
  openManageWidgetGallery() {
    this.modalService.open(ManageWidgetGalleryComponent, { size: 'lg' });
  }
  menuReinitialization() {
    setTimeout(() => {
      MenuComponent.reinitialization();
    }, 50);
  }
}
