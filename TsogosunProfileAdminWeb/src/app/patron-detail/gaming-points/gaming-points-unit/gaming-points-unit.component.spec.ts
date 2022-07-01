import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingPointsUnitComponent } from './gaming-points-unit.component';

describe('GamingPointsUnitComponent', () => {
  let component: GamingPointsUnitComponent;
  let fixture: ComponentFixture<GamingPointsUnitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingPointsUnitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingPointsUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
