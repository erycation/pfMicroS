import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateGroupLeaderboardComponent } from './update-group-leaderboard.component';

describe('UpdateGroupLeaderboardComponent', () => {
  let component: UpdateGroupLeaderboardComponent;
  let fixture: ComponentFixture<UpdateGroupLeaderboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateGroupLeaderboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateGroupLeaderboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
