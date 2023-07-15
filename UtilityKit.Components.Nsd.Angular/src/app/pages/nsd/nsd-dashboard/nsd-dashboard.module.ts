import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NsdDashboardRoutingModule } from './nsd-dashboard-routing.module';
import { NsdDashboardComponent } from './nsd-dashboard.component';
import { ManageNsdDashboardComponent } from './manage-nsd-dashboard/manage-nsd-dashboard.component';
import { InlineSVGModule } from 'ng-inline-svg-2';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { WidgetsListComponent } from './layout-container/widgets-list/widgets-list.component';
import { LayoutContainerComponent } from './layout-container/layout-container.component';
import { ManageWidgetSettingsComponent } from './layout-container/manage-widget-settings/manage-widget-settings.component';
import { ManageDataSourceComponent } from '../data-source/manage-data-source/manage-data-source.component';
import { UpdateWidgetDataSourceComponent } from './layout-container/update-widget-data-source/update-widget-data-source.component';
import { DxChartModule, DxButtonModule } from 'devextreme-angular';


@NgModule({
  declarations: [
    ManageNsdDashboardComponent,
    ManageDataSourceComponent,
    WidgetsListComponent,
    LayoutContainerComponent,
    ManageWidgetSettingsComponent,
    UpdateWidgetDataSourceComponent,
  ],
  imports: [
    CommonModule,
    NgbTooltipModule,
    ReactiveFormsModule,
    NsdDashboardRoutingModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    InlineSVGModule,
    DxChartModule,
    DxButtonModule,
  ],
})
export class NsdDashboardModule {}
