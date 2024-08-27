import { Component, EventEmitter, Host, HostBinding, HostListener, Inject, Input, Optional, Output, TemplateRef, ViewChild } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { Event } from '../../models/event';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MAT_DIALOG_DATA, MatDialogRef,MatDialog,MatDialogModule } from '@angular/material/dialog';
import { RouterLink, RouterOutlet, RouterLinkActive,Router } from '@angular/router';
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
      image: ['']
    });
  }
  

  onClose(): void {
    this.dialogRef.close(true);
  }

  ngOnInit(): void {
    console.log(this.event);
      this.getEvent(this.event);
  }

  getEvent(event: Event): void {
    this.events.push(event);
  }
  join(): void{
      this.dialogRef.close();
      this.router.navigate(['/events/join']);
  }
  
}
