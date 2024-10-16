import { Component } from '@angular/core';
import { EventsService } from '../../../services/events.service';
import { MatDialog } from '@angular/material/dialog';
import { Event } from '../../../models/event';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule} from '@angular/material/grid-list';
import { EventUser } from '../../../models/eventusers';
import { EventUsersService } from '../../../services/event-users.service';
import { FormsModule } from '@angular/forms';
import { SendMessageComponent } from '../../../components/send-message/send-message.component';
import { EventJoinCardComponent } from '../../../components/event-join-card/event-join-card.component';

@Component({
  selector: 'app-user-events',
  standalone: true,
  imports: [ MatInputModule, MatIconModule, CommonModule, MatPaginatorModule, MatSelectModule, MatGridListModule, FormsModule],
  templateUrl: './user-events.component.html',
  styleUrl: './user-events.component.scss'
})
export class UserEventsComponent {
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
    this.getEventUsers();
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

  getEventUsers(): void {
    let index = (this.selectedPage - 1) * this.usersPerPage;
    this.eventUserService.getEventUsers()
      .subscribe(attender => {
        this.userLength = attender.length;
        this.attenders =attender.slice(index, index + this.usersPerPage);
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
    this.getEventUsers();
  }
  nextPage(): void {
    if (this.selectedPage * this.usersPerPage < this.userLength) {
      this.selectedPage++;
    }
    this.getEventUsers();
  }

  onEventChange(event: any): void {
    const selected = event.value;
    const users: EventUser[] = [];
    this.eventUserService.getEventUsers()
      .subscribe(attend => {
        for (let i = 0; i < attend.length; i++) {{
          if (selected==attend[i].eventID){
             users.push(attend[i]);
           }
          }
        }
        this.attenders = users;
          return;
      });
  }

  onClick(): void {
    this.dialogRef.open(SendMessageComponent, {
      width: '30vw',
      height: '30vh'
    });
  }
  newJoin(): void {
    var inp=this.dialogRef.open(EventJoinCardComponent, {
      width: '35vw',
      height: '80vh'
    });
    inp.componentInstance.eventId = this.events[0].id;
    console.log("Event ID:", this.events[0].id);
  }
}
