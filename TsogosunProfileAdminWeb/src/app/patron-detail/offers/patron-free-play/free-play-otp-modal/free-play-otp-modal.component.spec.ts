import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreePlayOtpModalComponent } from './free-play-otp-modal.component';

describe('FreePlayOtpModalComponent', () => {
  let component: FreePlayOtpModalComponent;
  let fixture: ComponentFixture<FreePlayOtpModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FreePlayOtpModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FreePlayOtpModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
