import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NKSLKComponent } from './nkslk.component';

describe('NkslkComponent', () => {
  let component: NKSLKComponent;
  let fixture: ComponentFixture<NKSLKComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NKSLKComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NKSLKComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
