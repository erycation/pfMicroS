import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IgtPatronSearchAddressComponent } from './igt-patron-search-address.component';

describe('IgtPatronSearchAddressComponent', () => {
  let component: IgtPatronSearchAddressComponent;
  let fixture: ComponentFixture<IgtPatronSearchAddressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IgtPatronSearchAddressComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IgtPatronSearchAddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
