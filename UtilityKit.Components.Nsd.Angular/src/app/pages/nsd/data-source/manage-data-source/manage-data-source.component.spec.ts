import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageDataSourceComponent } from './manage-data-source.component';

describe('ManageDataSourceComponent', () => {
  let component: ManageDataSourceComponent;
  let fixture: ComponentFixture<ManageDataSourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageDataSourceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageDataSourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
