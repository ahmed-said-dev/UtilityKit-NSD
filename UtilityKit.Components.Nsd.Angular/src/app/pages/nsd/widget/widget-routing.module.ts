import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WidgetComponent } from './widget.component';
import { WidgetDetailsComponent } from './widget-details/widget-details.component';

const routes: Routes = [
  {
    path: '',
    component: WidgetComponent,
  },
  {
    path: 'details/:id',
    component: WidgetDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WidgetRoutingModule {}
