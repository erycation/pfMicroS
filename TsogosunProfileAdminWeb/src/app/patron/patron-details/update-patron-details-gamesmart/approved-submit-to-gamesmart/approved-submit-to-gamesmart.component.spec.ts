import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedSubmitToGamesmartComponent } from './approved-submit-to-gamesmart.component';

describe('ApprovedSubmitToGamesmartComponent', () => {
  let component: ApprovedSubmitToGamesmartComponent;
  let fixture: ComponentFixture<ApprovedSubmitToGamesmartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApprovedSubmitToGamesmartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedSubmitToGamesmartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
