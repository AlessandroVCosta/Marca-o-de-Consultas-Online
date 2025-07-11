import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentUser } from './appointment-user';

describe('AppointmentUser', () => {
  let component: AppointmentUser;
  let fixture: ComponentFixture<AppointmentUser>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppointmentUser]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentUser);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
