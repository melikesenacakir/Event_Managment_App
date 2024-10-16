import { Component, Input } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIcon } from '@angular/material/icon';
import { MatDialogRef } from '@angular/material/dialog';
import { firstValueFrom } from 'rxjs';
import { EventsService } from '../../services/events.service';
import { Event } from '../../models/event';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-join-card',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule, MatIcon],
  templateUrl: './event-join-card.component.html',
  styleUrl: './event-join-card.component.scss'
})
export class EventJoinCardComponent {
 joinForm: FormGroup;
 @Input() event: Event;
  eventId: number;
  eventName: string;
  constructor(private fb: FormBuilder, private dialogRef: MatDialogRef<EventJoinCardComponent>, private eventsService: EventsService,private route: ActivatedRoute) {
    this.joinForm = this.fb.group({
      name: [''],
      surname: [''],
      email: [''],
      enrollment: ['',Validators.min(0)]
    });
  }

  ngOnInit(): void { 
    this.route.queryParams.subscribe(params => {
      this.eventId = params['eventId'];
      this.eventName = params['eventName'];
    });
  }


  async submitForm(): Promise<void> {
    try {
      const event = await firstValueFrom(this.eventsService.joinEvent(this.eventId,this.joinForm.value));
      console.log("Event joined:", event);
    } catch (error) {
      console.error("Error fetching event:", error);
    }
  }


  close(){
    this.dialogRef.close(true);
  }
}
