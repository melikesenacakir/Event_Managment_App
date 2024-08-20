import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { MatGridListModule } from '@angular/material/grid-list';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-send-message',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule],
  templateUrl: './send-message.component.html',
  styleUrl: './send-message.component.scss'
})
export class SendMessageComponent {
  messageForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.messageForm = this.fb.group({
      message: ['']
    });
  }

}
