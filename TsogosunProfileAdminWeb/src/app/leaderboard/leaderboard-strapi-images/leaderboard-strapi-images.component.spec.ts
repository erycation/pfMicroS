import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaderboardStrapiImagesComponent } from './leaderboard-strapi-images.component';

describe('LeaderboardStrapiImagesComponent', () => {
  let component: LeaderboardStrapiImagesComponent;
  let fixture: ComponentFixture<LeaderboardStrapiImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaderboardStrapiImagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaderboardStrapiImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
