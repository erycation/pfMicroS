import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TileImagesComponent } from './tile-images.component';

describe('TileImagesComponent', () => {
  let component: TileImagesComponent;
  let fixture: ComponentFixture<TileImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TileImagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TileImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
