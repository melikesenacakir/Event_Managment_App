import { Component, EventEmitter, Host, HostBinding, HostListener, Inject, Input, Optional, Output, TemplateRef, ViewChild } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { Event } from '../../models/event';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MAT_DIALOG_DATA, MatDialogRef,MatDialog,MatDialogModule } from '@angular/material/dialog';
import { RouterLink, RouterOutlet, RouterLinkActive,Router, NavigationExtras } from '@angular/router';
import { JoinComponent } from './join/join.component';

@Component({
  selector: 'app-event-card',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule, RouterOutlet, RouterLink, RouterLinkActive, MatDialogModule,JoinComponent],
  templateUrl: './event-card.component.html',
  styleUrl: './event-card.component.scss', 
})
export class EventCardComponent {
  events: Event[];
  eventForm: FormGroup;
  @Input() event: Event;
  @ViewChild(TemplateRef, { static: true }) templateRef: TemplateRef<any>;

  constructor(private eventService: EventsService,
     private fb: FormBuilder,
     @Optional() public dialogRef: MatDialogRef<EventCardComponent>,
    // @Inject(MAT_DIALOG_DATA) public data: { event: Event },
     private router: Router) {
    this.events = [];
    this.eventForm = this.fb.group({
      id: [''],
      title: [''],
      description: [''],
      date: [''],
      location: [''],
      time: [''],
      image: ['']
    });
  }
  

  onClose(): void {
    if(this.dialogRef){
      this.dialogRef.close();
    }
  }

  ngOnInit(): void {
    this.getEvent(this.event);
  }

  getEvent(event: Event): void {
    this.events.push(event);
  }
  join(): void{
    if(this.dialogRef){
      this.dialogRef.close();
    }
    const navigationExtras: NavigationExtras = {
      queryParams: { eventId: this.event.id, eventName: this.event.title }
    };

      this.router.navigate(['/events/join'], navigationExtras);
  }
  
}
