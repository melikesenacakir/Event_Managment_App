import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventJoinCardComponent } from './event-join-card.component';

describe('EventJoinCardComponent', () => {
  let component: EventJoinCardComponent;
  let fixture: ComponentFixture<EventJoinCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventJoinCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventJoinCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
