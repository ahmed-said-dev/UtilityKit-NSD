import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateWidgetDataSourceComponent } from './update-widget-data-source.component';

describe('UpdateWidgetDataSourceComponent', () => {
  let component: UpdateWidgetDataSourceComponent;
  let fixture: ComponentFixture<UpdateWidgetDataSourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateWidgetDataSourceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateWidgetDataSourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
