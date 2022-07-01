import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateConfigurePriceModalComponent } from './update-configure-price-modal.component';

describe('UpdateConfigurePriceModalComponent', () => {
  let component: UpdateConfigurePriceModalComponent;
  let fixture: ComponentFixture<UpdateConfigurePriceModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateConfigurePriceModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateConfigurePriceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
