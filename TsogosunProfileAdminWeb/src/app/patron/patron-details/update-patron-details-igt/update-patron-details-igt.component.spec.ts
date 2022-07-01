import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePatronDetailsIgtComponent } from './update-patron-details-igt.component';

describe('UpdatePatronDetailsIgtComponent', () => {
  let component: UpdatePatronDetailsIgtComponent;
  let fixture: ComponentFixture<UpdatePatronDetailsIgtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatePatronDetailsIgtComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatePatronDetailsIgtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
