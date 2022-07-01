import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronDetailsApprovedComponent } from './patron-details-approved.component';

describe('PatronDetailsApprovedComponent', () => {
  let component: PatronDetailsApprovedComponent;
  let fixture: ComponentFixture<PatronDetailsApprovedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronDetailsApprovedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronDetailsApprovedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
