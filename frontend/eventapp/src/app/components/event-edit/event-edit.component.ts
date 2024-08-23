import { Component, EventEmitter, Host, HostBinding, HostListener, Inject, Optional, Output } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { Event } from '../../models/event';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MAT_DIALOG_DATA, MatDialogRef,MatDialog,MatDialogModule } from '@angular/material/dialog';
@Component({
  selector: 'app-event-edit',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, CommonModule, MatGridListModule],
  templateUrl: './event-edit.component.html',
  styleUrl: './event-edit.component.scss'
})
export class EventEditComponent {
  events: Event[];
  eventForm: FormGroup;
  action: string= 'Edit';

  constructor(private eventService: EventsService,
     private fb: FormBuilder,
     @Optional() public dialogRef: MatDialogRef<EventEditComponent>,
     @Inject(MAT_DIALOG_DATA) public data: { event: Event }) {
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
      this.getEvent(this.data?.event);
  }

  getEvent(event: Event): void {
    this.events.push(event);
  }
  edit(): void{
    this.action = 'Save';

    
  }
  
}
