import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateActiveDateModalComponent } from './update-active-date-modal.component';

describe('UpdateActiveDateModalComponent', () => {
  let component: UpdateActiveDateModalComponent;
  let fixture: ComponentFixture<UpdateActiveDateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateActiveDateModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateActiveDateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
