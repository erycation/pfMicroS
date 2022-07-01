import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedSubmitToIgtComponent } from './approved-submit-to-igt.component';

describe('ApprovedSubmitToIgtComponent', () => {
  let component: ApprovedSubmitToIgtComponent;
  let fixture: ComponentFixture<ApprovedSubmitToIgtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApprovedSubmitToIgtComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedSubmitToIgtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
