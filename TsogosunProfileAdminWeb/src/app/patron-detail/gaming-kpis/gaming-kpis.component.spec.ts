import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingKpisComponent } from './gaming-kpis.component';

describe('GamingKpisComponent', () => {
  let component: GamingKpisComponent;
  let fixture: ComponentFixture<GamingKpisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingKpisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingKpisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
