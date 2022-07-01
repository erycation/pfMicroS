import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamesmartPatronSearchAddressComponent } from './gamesmart-patron-search-address.component';

describe('GamesmartPatronSearchAddressComponent', () => {
  let component: GamesmartPatronSearchAddressComponent;
  let fixture: ComponentFixture<GamesmartPatronSearchAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamesmartPatronSearchAddressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamesmartPatronSearchAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
