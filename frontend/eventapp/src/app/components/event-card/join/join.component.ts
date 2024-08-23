import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-join',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatGridListModule, MatRadioModule, MatIconModule, MatCheckboxModule],
  templateUrl: './join.component.html',
  styleUrl: './join.component.scss'
})
export class JoinComponent {
  joinForm: FormGroup;

  constructor(private fb: FormBuilder) {
    debugger;
    this.joinForm = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', Validators.email],
      attend: [false],
    });
  }
}
