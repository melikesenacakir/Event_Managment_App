import { Component, Optional } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { MatGridListModule } from '@angular/material/grid-list';
import { CommonModule } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-send-message',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule],
  templateUrl: './send-message.component.html',
  styleUrl: './send-message.component.scss'
})
export class SendMessageComponent {
  messageForm: FormGroup;
  constructor(private fb: FormBuilder,@Optional() public dialogRef: MatDialogRef<SendMessageComponent>) {
    this.messageForm = this.fb.group({
      message: ['']
    });
  }

  onCancel() {
    this.messageForm.reset();
    this.dialogRef.close(true);
  }

}
