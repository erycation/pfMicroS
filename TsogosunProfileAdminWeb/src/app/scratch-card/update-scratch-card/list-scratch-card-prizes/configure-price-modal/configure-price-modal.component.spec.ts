import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurePriceModalComponent } from './configure-price-modal.component';

describe('ConfigurePriceModalComponent', () => {
  let component: ConfigurePriceModalComponent;
  let fixture: ComponentFixture<ConfigurePriceModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfigurePriceModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurePriceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
