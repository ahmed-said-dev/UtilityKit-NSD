import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NsdDashboardComponent } from './nsd-dashboard.component';

describe('NsdDashboardComponent', () => {
  let component: NsdDashboardComponent;
  let fixture: ComponentFixture<NsdDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NsdDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NsdDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
