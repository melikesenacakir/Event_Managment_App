import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatRadioModule } from '@angular/material/radio';
import { Router } from '@angular/router';
import { User } from '../../models/user';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatRadioModule,
    MatGridListModule
  ],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  action: string = 'Edit';
  profileForm: FormGroup;
  isVisible: boolean = false;
  users : User[];

  constructor(private fb: FormBuilder, private router: Router, private userService: UsersService) {
    this.profileForm = this.fb.group({
      username: [{ value: '', disabled: true }],
      password: [{ value: '', disabled: true }],
      name: [{ value: '', disabled: true }],
      surname: [{ value: '', disabled: true }],
      email: [{ value: '', disabled: true }, [Validators.required, Validators.email]],
      newPassword: [''],
      confirmPassword: ['', Validators.required]
    });
    this.users=[];
  }

  ngOnInit(): void {
    this.getUser(4);
    this.profileForm.get('username')?.setValue(this.users[0].username);
  }

  getUsers(): void {
    this.userService.getUsers()
    .subscribe(users => this.users = users);
  }

  getUser(id: number): void {
    this.userService.getUser(id)
    .subscribe(user => {
      if (user) {
        this.users.push(user);
      }
    });
  }

  onSubmit() {
    if (this.action === 'Edit') {
      this.disableFormFields();
      this.isVisible = false;
    } else if (this.action === 'Save') {
      this.enableFormFields();
      this.isVisible = true;
    }
  }

  btnAction() {
    this.action = this.action === 'Edit' ? 'Save' : 'Edit';
  }

  btnCancel() {
    this.action = 'Edit';
    this.onSubmit();

  }

  private enableFormFields() {
    this.profileForm.get('username')?.enable();
    this.profileForm.get('password')?.enable();
    this.profileForm.get('name')?.enable();
    this.profileForm.get('surname')?.enable();
    this.profileForm.get('email')?.enable();
  }

  private disableFormFields() {
    this.profileForm.get('username')?.disable();
    this.profileForm.get('password')?.disable();
    this.profileForm.get('name')?.disable();
    this.profileForm.get('surname')?.disable();
    this.profileForm.get('email')?.disable();
  }
}
