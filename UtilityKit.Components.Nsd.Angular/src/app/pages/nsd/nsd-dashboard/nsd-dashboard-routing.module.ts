import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NsdDashboardComponent } from './nsd-dashboard.component';
import { LayoutContainerComponent } from './layout-container/layout-container.component';

const routes: Routes = [
  {
    path: '',
    component: NsdDashboardComponent,
  },
  {
    path: 'layout/:id',
    component: LayoutContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NsdDashboardRoutingModule {}
