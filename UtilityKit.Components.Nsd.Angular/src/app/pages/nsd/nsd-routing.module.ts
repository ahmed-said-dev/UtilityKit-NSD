import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NsdComponent } from './nsd.component';
import { NsdDashboardComponent } from './nsd-dashboard/nsd-dashboard.component';
import { WidgetComponent } from './widget/widget.component';
import { DataSourceComponent } from './data-source/data-source.component';

const routes: Routes = [
  {
    path: '',
    component: NsdComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import('./nsd-dashboard/nsd-dashboard.module').then(
            (m) => m.NsdDashboardModule
          ),
      },
      {
        path: 'widget',
        loadChildren: () =>
          import('./widget/widget.module').then((m) => m.WidgetModule),
      },
      {
        path: 'data-source',
        component: DataSourceComponent,
      },
      {
        path: '',
        redirectTo: '/nsd/dashboard',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NsdRoutingModule {}
