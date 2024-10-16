import {  Component } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { CommonModule } from '@angular/common';
import { Event } from '../../models/event';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogRef , MatDialogModule} from '@angular/material/dialog';
import { EventCardComponent } from '../../components/event-card/event-card.component';
import { Router, RouterOutlet } from '@angular/router';
import { firstValueFrom, Observable } from 'rxjs';


@Component({
  selector: 'app-event',
  standalone: true,
  imports: [CommonModule, MatPaginatorModule, FormsModule, MatSelectModule, MatFormFieldModule, MatInputModule, MatIconModule,RouterOutlet],
  templateUrl: './event.component.html',
  styleUrl: './event.component.scss',
})
export class EventComponent {
  events: Event[];
  event: Event; 
  eventsPerPage: number = 5
  selectedPage: number = 1;
  eventLength: number = 0;
  isHidePageSize: boolean = true;
  notFound: boolean = false;

  months = [
    { name: 'All', value: 0 },
    { name: 'January', value: 1 },
    { name: 'February', value: 2 },
    { name: 'March', value: 3 },
    { name: 'April', value: 4 },
    { name: 'May', value: 5 },
    { name: 'June', value: 6 },
    { name: 'July', value: 7 },
    { name: 'August', value: 8 },
    { name: 'September', value: 9 },
    { name: 'October', value: 10 },
    { name: 'November', value: 11 },
    { name: 'December', value: 12 }
  ];


  constructor(private eventService: EventsService,
    private dialogRef: MatDialog,
    private router: Router
  ) {
    this.events = [];
  }

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents(): void {
    let index = (this.selectedPage - 1) * this.eventsPerPage;
    this.eventService.getEvents()
      .subscribe(events => {
        this.eventLength = events.length;
          this.events = events.sort((a, b) => {
          const dateA = new Date(a.date);
          const dateB = new Date(b.date);
          return dateB.getTime() - dateA.getTime();
        });
        this.events = events.slice(index, index + this.eventsPerPage);
      });
  }

  async getEvent(id: number): Promise<void> {
    try {
      const event = await firstValueFrom(this.eventService.getEvent(id));
      if (event) {
        this.event = event;
      }
    } catch (error) {
      console.error("Error fetching event:", error);
    }
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

  navigatePage(page: PageEvent): void {
    if (page.pageIndex + 1 > this.selectedPage) {
      this.selectedPage++;
    } else if (page.pageIndex < this.selectedPage) {
      if (this.selectedPage > 1) {
        this.selectedPage--;
      }
    }
    this.getEvents();
  }

  nextPage(): void {
    if (this.selectedPage * this.eventsPerPage < this.eventLength) {
      this.selectedPage++;
      this.getEvents();
    }
  }

  onEventChange(event: any): void {
    const selected = event.value;
    this.eventService.getEvents()
      .subscribe(events => {
        if (selected == 0) {
          this.getEvents();
          return;
        } else {
          this.events = events.filter(e => new Date(e.date).getMonth() === selected - 1);
        }
        this.eventLength = this.events.length;
      });
    if (this.events.length == 0) {
      this.notFound = true;
    } else {
      this.notFound = false;
    }
  }
 
  async onClick(id: number): Promise<void> {
    await this.getEvent(id);
     const inp= this.dialogRef.open(EventCardComponent, {
        width: '23vw',
        height: '80vh',
        data: { event: this.event }
      });
      inp.componentInstance.event = this.event;
  }
}
