import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentAnon } from './appointment-anon';

describe('AppointmentAnon', () => {
  let component: AppointmentAnon;
  let fixture: ComponentFixture<AppointmentAnon>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentAnon]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentAnon);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
