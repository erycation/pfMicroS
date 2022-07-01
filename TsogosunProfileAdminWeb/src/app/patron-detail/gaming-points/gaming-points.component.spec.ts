import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingPointsComponent } from './gaming-points.component';

describe('GamingPointsComponent', () => {
  let component: GamingPointsComponent;
  let fixture: ComponentFixture<GamingPointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingPointsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingPointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
