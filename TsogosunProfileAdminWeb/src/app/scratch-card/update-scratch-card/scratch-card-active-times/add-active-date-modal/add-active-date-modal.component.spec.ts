import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddActiveDateModalComponent } from './add-active-date-modal.component';

describe('AddActiveDateModalComponent', () => {
  let component: AddActiveDateModalComponent;
  let fixture: ComponentFixture<AddActiveDateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddActiveDateModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddActiveDateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
