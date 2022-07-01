import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLeaderboardComponent } from './add-leaderboard.component';

describe('AddLeaderboardComponent', () => {
  let component: AddLeaderboardComponent;
  let fixture: ComponentFixture<AddLeaderboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLeaderboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLeaderboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
