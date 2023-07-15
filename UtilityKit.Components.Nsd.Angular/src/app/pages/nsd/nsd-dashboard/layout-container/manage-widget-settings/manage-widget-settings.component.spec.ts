import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageWidgetSettingsComponent } from './manage-widget-settings.component';

describe('ManageWidgetSettingsComponent', () => {
  let component: ManageWidgetSettingsComponent;
  let fixture: ComponentFixture<ManageWidgetSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageWidgetSettingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageWidgetSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
