import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingKpisUnitComponent } from './gaming-kpis-unit.component';

describe('GamingKpisUnitComponent', () => {
  let component: GamingKpisUnitComponent;
  let fixture: ComponentFixture<GamingKpisUnitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingKpisUnitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingKpisUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
