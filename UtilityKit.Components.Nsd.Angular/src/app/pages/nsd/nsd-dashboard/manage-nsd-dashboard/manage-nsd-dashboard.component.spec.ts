import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageNsdDashboardComponent } from './manage-nsd-dashboard.component';

describe('ManageNsdDashboardComponent', () => {
  let component: ManageNsdDashboardComponent;
  let fixture: ComponentFixture<ManageNsdDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageNsdDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageNsdDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
