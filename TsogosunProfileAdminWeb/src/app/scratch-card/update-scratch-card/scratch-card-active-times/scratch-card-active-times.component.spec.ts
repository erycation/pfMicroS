import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScratchCardActiveTimesComponent } from './scratch-card-active-times.component';

describe('ScratchCardActiveTimesComponent', () => {
  let component: ScratchCardActiveTimesComponent;
  let fixture: ComponentFixture<ScratchCardActiveTimesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScratchCardActiveTimesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScratchCardActiveTimesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
