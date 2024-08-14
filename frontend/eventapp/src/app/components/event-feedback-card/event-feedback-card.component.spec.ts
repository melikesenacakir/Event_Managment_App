import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventFeedbackCardComponent } from './event-feedback-card.component';

describe('EventFeedbackCardComponent', () => {
  let component: EventFeedbackCardComponent;
  let fixture: ComponentFixture<EventFeedbackCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventFeedbackCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventFeedbackCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
