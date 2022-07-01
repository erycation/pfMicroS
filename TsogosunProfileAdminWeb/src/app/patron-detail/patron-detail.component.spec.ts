import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronDetailComponent } from './patron-detail.component';

describe('PatronDetailComponent', () => {
  let component: PatronDetailComponent;
  let fixture: ComponentFixture<PatronDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
