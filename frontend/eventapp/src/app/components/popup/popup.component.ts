import { DialogRef } from '@angular/cdk/dialog';
import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialogRef,MatDialogModule } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { MatGridList,MatGridListModule } from '@angular/material/grid-list';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-popup',
  standalone: true,
  imports: [MatDialogModule,CommonModule,MatGridListModule,ReactiveFormsModule],
  templateUrl: './popup.component.html',
  styleUrl: './popup.component.scss'
})
export class PopupComponent {
  @Input() message: string;
  constructor(public dialogRef: MatDialogRef<PopupComponent>) {

  }

  closePopup() {
    this.dialogRef.close(true);
  }
}
