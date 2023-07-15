import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageWidgetGalleryComponent } from './manage-widget-gallery.component';

describe('ManageWidgetGalleryComponent', () => {
  let component: ManageWidgetGalleryComponent;
  let fixture: ComponentFixture<ManageWidgetGalleryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageWidgetGalleryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageWidgetGalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
