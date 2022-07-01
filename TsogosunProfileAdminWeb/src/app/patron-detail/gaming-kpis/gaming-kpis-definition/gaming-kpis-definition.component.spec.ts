import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingKpisDefinitionComponent } from './gaming-kpis-definition.component';

describe('GamingKpisDefinitionComponent', () => {
  let component: GamingKpisDefinitionComponent;
  let fixture: ComponentFixture<GamingKpisDefinitionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamingKpisDefinitionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingKpisDefinitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
