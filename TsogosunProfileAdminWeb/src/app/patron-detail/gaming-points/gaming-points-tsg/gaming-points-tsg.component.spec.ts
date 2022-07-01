import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingPointsTsgComponent } from './gaming-points-tsg.component';

describe('GamingPointsTsgComponent', () => {
  let component: GamingPointsTsgComponent;
  let fixture: ComponentFixture<GamingPointsTsgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingPointsTsgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingPointsTsgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
