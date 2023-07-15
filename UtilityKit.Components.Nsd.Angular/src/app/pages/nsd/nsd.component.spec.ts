import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NsdComponent } from './nsd.component';

describe('NsdComponent', () => {
  let component: NsdComponent;
  let fixture: ComponentFixture<NsdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NsdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NsdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
