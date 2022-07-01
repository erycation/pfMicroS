import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VoucherOtpModalComponent } from './voucher-otp-modal.component';

describe('VoucherOtpModalComponent', () => {
  let component: VoucherOtpModalComponent;
  let fixture: ComponentFixture<VoucherOtpModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VoucherOtpModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VoucherOtpModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
