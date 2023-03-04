import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NetiquetaComponent } from './netiqueta.component';

describe('NetiquetaComponent', () => {
  let component: NetiquetaComponent;
  let fixture: ComponentFixture<NetiquetaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NetiquetaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NetiquetaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
