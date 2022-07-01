import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePatronDetailsGamesmartComponent } from './update-patron-details-gamesmart.component';

describe('UpdatePatronDetailsGamesmartComponent', () => {
  let component: UpdatePatronDetailsGamesmartComponent;
  let fixture: ComponentFixture<UpdatePatronDetailsGamesmartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatePatronDetailsGamesmartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatePatronDetailsGamesmartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
