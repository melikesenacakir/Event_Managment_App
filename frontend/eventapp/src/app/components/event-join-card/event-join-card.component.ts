import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-event-join-card',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule, MatIcon],
  templateUrl: './event-join-card.component.html',
  styleUrl: './event-join-card.component.scss'
})
export class EventJoinCardComponent {
 joinForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.joinForm = this.fb.group({
      name: [''],
      surname: [''],
      email: [''],
      enrollment: ['',Validators.min(0)]
    });
  }
}
