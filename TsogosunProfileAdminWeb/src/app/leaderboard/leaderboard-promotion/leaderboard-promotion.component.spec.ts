import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderboardPromotionComponent } from './leaderboard-promotion.component';

describe('LeaderboardPromotionComponent', () => {
  let component: LeaderboardPromotionComponent;
  let fixture: ComponentFixture<LeaderboardPromotionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderboardPromotionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaderboardPromotionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
