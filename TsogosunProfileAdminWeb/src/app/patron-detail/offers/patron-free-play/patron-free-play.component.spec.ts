import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronFreePlayComponent } from './patron-free-play.component';

describe('PatronFreePlayComponent', () => {
  let component: PatronFreePlayComponent;
  let fixture: ComponentFixture<PatronFreePlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronFreePlayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronFreePlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
