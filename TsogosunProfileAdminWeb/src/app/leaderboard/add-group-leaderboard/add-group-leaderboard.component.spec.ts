import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGroupLeaderboardComponent } from './add-group-leaderboard.component';

describe('AddGroupLeaderboardComponent', () => {
  let component: AddGroupLeaderboardComponent;
  let fixture: ComponentFixture<AddGroupLeaderboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGroupLeaderboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGroupLeaderboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
