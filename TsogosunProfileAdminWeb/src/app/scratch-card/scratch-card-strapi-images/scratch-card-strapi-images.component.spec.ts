import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScratchCardStrapiImagesComponent } from './scratch-card-strapi-images.component';

describe('ScratchCardStrapiImagesComponent', () => {
  let component: ScratchCardStrapiImagesComponent;
  let fixture: ComponentFixture<ScratchCardStrapiImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScratchCardStrapiImagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScratchCardStrapiImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
