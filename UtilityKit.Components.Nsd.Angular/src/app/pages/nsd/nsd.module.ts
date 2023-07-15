import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NsdRoutingModule } from './nsd-routing.module';
import { NsdComponent } from './nsd.component';
import { NsdDashboardComponent } from './nsd-dashboard/nsd-dashboard.component';
import { WidgetComponent } from './widget/widget.component';
import { DataSourceComponent } from './data-source/data-source.component';
import { InlineSVGModule } from 'ng-inline-svg-2';

@NgModule({
  declarations: [
    NsdComponent,
    NsdDashboardComponent,
    WidgetComponent,
    DataSourceComponent,
  ],
  imports: [CommonModule, NsdRoutingModule, InlineSVGModule],
})
export class NsdModule {}
