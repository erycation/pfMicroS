import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LosingImagesComponent } from './losing-images.component';

describe('LosingImagesComponent', () => {
  let component: LosingImagesComponent;
  let fixture: ComponentFixture<LosingImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LosingImagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LosingImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
