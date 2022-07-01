import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronDetailScratchCardComponent } from './patron-detail-scratch-card.component';

describe('PatronDetailScratchCardComponent', () => {
  let component: PatronDetailScratchCardComponent;
  let fixture: ComponentFixture<PatronDetailScratchCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronDetailScratchCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronDetailScratchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
