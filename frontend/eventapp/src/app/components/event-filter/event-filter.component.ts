import { Component, Optional } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatRadioGroup,MatRadioButton } from '@angular/material/radio';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Event } from '@angular/router';

@Component({
  selector: 'app-event-filter',
  standalone: true,
  imports: [MatGridListModule, CommonModule, MatRadioGroup, MatRadioButton, ReactiveFormsModule],
  templateUrl: './event-filter.component.html',
  styleUrl: './event-filter.component.scss'
})
export class EventFilterComponent {
 filterForm: FormGroup;
  constructor(private fb: FormBuilder,@Optional() public dialogRef: MatDialogRef<EventFilterComponent>) {
    this.filterForm = this.fb.group({
      filter: ['']
    });
    
  }

  select(event: any){
      this.dialogRef.close(true);
  }
}
