import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveScratchCardComponent } from './active-scratch-card.component';

describe('ActiveScratchCardComponent', () => {
  let component: ActiveScratchCardComponent;
  let fixture: ComponentFixture<ActiveScratchCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveScratchCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveScratchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
