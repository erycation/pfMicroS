import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingKpisTsgComponent } from './gaming-kpis-tsg.component';

describe('GamingKpisTsgComponent', () => {
  let component: GamingKpisTsgComponent;
  let fixture: ComponentFixture<GamingKpisTsgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingKpisTsgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingKpisTsgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
