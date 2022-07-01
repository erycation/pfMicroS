import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WinningImagesComponent } from './winning-images.component';

describe('WinningImagesComponent', () => {
  let component: WinningImagesComponent;
  let fixture: ComponentFixture<WinningImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WinningImagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WinningImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
