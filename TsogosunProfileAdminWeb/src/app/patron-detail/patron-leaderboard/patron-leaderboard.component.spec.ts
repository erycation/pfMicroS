import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronLeaderboardComponent } from './patron-leaderboard.component';

describe('PatronLeaderboardComponent', () => {
  let component: PatronLeaderboardComponent;
  let fixture: ComponentFixture<PatronLeaderboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronLeaderboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronLeaderboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
