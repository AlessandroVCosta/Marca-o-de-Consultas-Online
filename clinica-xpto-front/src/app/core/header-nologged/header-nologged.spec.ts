import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderNologged } from './header-nologged';

describe('HeaderNologged', () => {
  let component: HeaderNologged;
  let fixture: ComponentFixture<HeaderNologged>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderNologged]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeaderNologged);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
