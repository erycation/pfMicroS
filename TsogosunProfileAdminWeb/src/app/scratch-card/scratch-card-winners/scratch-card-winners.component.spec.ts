import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScratchCardWinnersComponent } from './scratch-card-winners.component';

describe('ScratchCardWinnersComponent', () => {
  let component: ScratchCardWinnersComponent;
  let fixture: ComponentFixture<ScratchCardWinnersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScratchCardWinnersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScratchCardWinnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
