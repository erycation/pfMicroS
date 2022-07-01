import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListScratchCardPrizesComponent } from './list-scratch-card-prizes.component';

describe('ListScratchCardPrizesComponent', () => {
  let component: ListScratchCardPrizesComponent;
  let fixture: ComponentFixture<ListScratchCardPrizesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListScratchCardPrizesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListScratchCardPrizesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
