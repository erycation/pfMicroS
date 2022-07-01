import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddScratchCardComponent } from './add-scratch-card.component';

describe('AddScratchCardComponent', () => {
  let component: AddScratchCardComponent;
  let fixture: ComponentFixture<AddScratchCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddScratchCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddScratchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
