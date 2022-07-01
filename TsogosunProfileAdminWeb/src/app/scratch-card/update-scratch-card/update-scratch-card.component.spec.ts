import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateScratchCardComponent } from './update-scratch-card.component';

describe('UpdateScratchCardComponent', () => {
  let component: UpdateScratchCardComponent;
  let fixture: ComponentFixture<UpdateScratchCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateScratchCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateScratchCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
