import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatronDrawComponent } from './patron-draw.component';

describe('PatronDrawComponent', () => {
  let component: PatronDrawComponent;
  let fixture: ComponentFixture<PatronDrawComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatronDrawComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatronDrawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
