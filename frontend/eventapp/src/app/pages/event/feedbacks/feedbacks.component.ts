import { Component } from '@angular/core';
import { EventUsersService } from '../../../services/event-users.service';
import { EventsService } from '../../../services/events.service';
import { MatDialog } from '@angular/material/dialog';
import { EventUser } from '../../../models/eventusers';
import { Event } from '../../../models/event';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule} from '@angular/material/grid-list';
import {MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { EventFilterComponent } from '../../../components/event-filter/event-filter.component';

@Component({
  selector: 'app-feedbacks',
  standalone: true,
  imports: [MatInputModule, MatIconModule, CommonModule, MatSelectModule, MatGridListModule, MatPaginatorModule],
  templateUrl: './feedbacks.component.html',
  styleUrl: './feedbacks.component.scss'
})
export class FeedbacksComponent {
  events: Event[];
  attenders: EventUser[];
  usersPerPage: number = 6;
  selectedPage: number = 1;
  userLength: number = 0;
  isHidePageSize: boolean = true;

  
  constructor(private eventService: EventsService,
    private dialogRef: MatDialog,
    private eventUserService: EventUsersService
  ) {
    this.events = [];
    this.attenders = [];
  }

  ngOnInit(): void {
    this.getEvents();
  }


  getEvents(): void {
    this.eventService.getEvents()
      .subscribe(events => {
          this.events = events.sort((a, b) => {
          const dateA = new Date(a.date);
          const dateB = new Date(b.date);
          return dateB.getTime() - dateA.getTime();
        });
      });
  }

  navigatePage(page: PageEvent): void {
    if (page.pageIndex + 1 > this.selectedPage) {
      this.selectedPage++;
    } else if (page.pageIndex < this.selectedPage) {
      if (this.selectedPage > 1) {
        this.selectedPage--;
      }
    }
   // this.getEventUsers();
  }
  onClick(): void {
    this.dialogRef.open(EventFilterComponent, {
      width: '10vw',
      height: '30vh'
    });
  }
}
