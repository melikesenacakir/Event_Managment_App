import { Component } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { CommonModule } from '@angular/common';
import { Event } from '../../models/event';


@Component({
  selector: 'app-event',
  standalone: true,
  imports: [  CommonModule],
  templateUrl: './event.component.html',
  styleUrl: './event.component.scss'
})
export class EventComponent {
 events: Event[];

  constructor(private eventService: EventsService) {
    this.events = [];
  }

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents(): void {
    this.eventService.getEvents()
    .subscribe(events => this.events = events);
  }

  getEvent(id: number): void {
    this.eventService.getEvent(id)
    .subscribe(event => {
      if (event) {
        this.events.push(event);
      }
    });
  }

  deleteEvent(event: Event): void {
    this.events = this.events.filter(e => e !== event);
    this.eventService.deleteEvent(event).subscribe();
  }

  createEvent(event: Event): void {
    this.eventService.createEvent(event).subscribe();
  }

  updateEvent(event: Event): void {
    this.eventService.updateEvent(event).subscribe();
  }

}
