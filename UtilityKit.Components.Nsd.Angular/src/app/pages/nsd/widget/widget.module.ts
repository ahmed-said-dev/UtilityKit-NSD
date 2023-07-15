import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WidgetComponent } from './widget.component';
import { ManageWidgetGalleryComponent } from './widget-details/manage-widget-gallery/manage-widget-gallery.component';
import { InlineSVGModule } from 'ng-inline-svg-2';
import { ManageConfigurationsComponent } from './widget-details/manage-configurations/manage-configurations.component';
import { WidgetDetailsComponent } from './widget-details/widget-details.component';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { WidgetRoutingModule } from './widget-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [
    ManageWidgetGalleryComponent,
    ManageConfigurationsComponent,
    WidgetDetailsComponent,
  ],
  imports: [
    CommonModule,
    NgbTooltipModule,
    ReactiveFormsModule,
    WidgetRoutingModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    InlineSVGModule,
  ],
})
export class WidgetModule {}
