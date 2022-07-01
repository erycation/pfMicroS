import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronScratchCardComponent } from './patron-scratch-card.component';

describe('PatronScratchCardComponent', () => {
  let component: PatronScratchCardComponent;
  let fixture: ComponentFixture<PatronScratchCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronScratchCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronScratchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
