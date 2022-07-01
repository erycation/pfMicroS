import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronDetailsInProgressComponent } from './patron-details-in-progress.component';

describe('PatronDetailsInProgressComponent', () => {
  let component: PatronDetailsInProgressComponent;
  let fixture: ComponentFixture<PatronDetailsInProgressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronDetailsInProgressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronDetailsInProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
