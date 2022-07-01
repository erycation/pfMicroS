import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardScratchCardComponent } from './dashboard-scratch-card.component';

describe('DashboardScratchCardComponent', () => {
  let component: DashboardScratchCardComponent;
  let fixture: ComponentFixture<DashboardScratchCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardScratchCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardScratchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
