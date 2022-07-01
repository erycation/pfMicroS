import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertErrorDialogComponent } from './alert-error-dialog.component';

describe('AlertErrorDialogComponent', () => {
  let component: AlertErrorDialogComponent;
  let fixture: ComponentFixture<AlertErrorDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlertErrorDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlertErrorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
