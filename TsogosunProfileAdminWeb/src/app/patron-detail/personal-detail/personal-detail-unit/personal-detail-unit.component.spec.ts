import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalDetailUnitComponent } from './personal-detail-unit.component';

describe('PersonalDetailUnitComponent', () => {
  let component: PersonalDetailUnitComponent;
  let fixture: ComponentFixture<PersonalDetailUnitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonalDetailUnitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalDetailUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
