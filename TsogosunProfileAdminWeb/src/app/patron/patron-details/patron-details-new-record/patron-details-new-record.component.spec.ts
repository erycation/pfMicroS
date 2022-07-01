import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronDetailsNewRecordComponent } from './patron-details-new-record.component';

describe('PatronDetailsNewRecordComponent', () => {
  let component: PatronDetailsNewRecordComponent;
  let fixture: ComponentFixture<PatronDetailsNewRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronDetailsNewRecordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronDetailsNewRecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
