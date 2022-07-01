import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalDetailTsgComponent } from './personal-detail-tsg.component';

describe('PersonalDetailTsgComponent', () => {
  let component: PersonalDetailTsgComponent;
  let fixture: ComponentFixture<PersonalDetailTsgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonalDetailTsgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalDetailTsgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
