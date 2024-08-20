import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-event-feedback-card',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule],
  templateUrl: './event-feedback-card.component.html',
  styleUrl: './event-feedback-card.component.scss'
})
export class EventFeedbackCardComponent {

}
