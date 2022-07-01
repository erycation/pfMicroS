import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronVoucherComponent } from './patron-voucher.component';

describe('PatronVoucherComponent', () => {
  let component: PatronVoucherComponent;
  let fixture: ComponentFixture<PatronVoucherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronVoucherComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
