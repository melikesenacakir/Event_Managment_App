import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {NavbarComponent } from '../../components/navbar/navbar.component';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatRadioModule,MatGridListModule,NavbarComponent,RouterLink, RouterLinkActive],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup;
  loginError: string = '';
  @Input() login: boolean=true;
  
  constructor(private fb: FormBuilder, private router: Router) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required], //validators.required usernamein girilmesini zorunlu tutar
      password: ['', Validators.required],
      forgetpassword: [],
    });
  }

  private isFormEmpty = (): boolean => {
    return this.loginForm.get('username')?.value === '' || this.loginForm.get('password')?.value === '';
  } //form içindeki username ve passwordu alırız ve boş olup olmadığını kontrol ederiz(ek güvenlik). Burdaki ? işareti null değilse anlamında

  openNewPasswordPage(){
      this.router.navigateByUrl('/forgetpass');
      console.log(this.login)
  }
  onSubmit() : void {
    if (this.isFormEmpty()) {
       this.loginError = 'Username and password are required';
       return;
    }
    
  }
  onClick() : void {

  }
  
}

/* import { Component } from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {NavbarComponent } from '../navbar/navbar.component';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatRadioModule,MatGridListModule,NavbarComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup;
  loginError: string = '';
  inputs=[
    {
       title: 'login',
       lInput: [
        {
          type: 'text',
          label: 'Username',
          placeholder: 'Enter your username',
          formControlName: 'username'
        },
        {
          type: 'password',
          label: 'Password',
          placeholder: 'Enter your password',
          formControlName: 'password'
        },
        {
          type: 'checkbox',
          label: 'Forget Password',
          formControlName: 'forgetpassword'
        }
      ]
    },
    {
      title: 'register',
      lInput: [
        {
          type: 'text',
          label: 'Name',
          placeholder: 'Enter your name',
          formControlName: 'name'
        },
        {
          type: 'text',
          label: 'Surname',
          placeholder: 'Enter your surname',
          formControlName: 'surname'
        },
        {
          type: 'text',
          label: 'Username',
          placeholder: 'Enter your username',
          formControlName: 'username'
        },
        {
          type: 'email',
          label: 'Email',
          placeholder: 'Enter your email',
          formControlName: 'email'
        },
        {
          type: 'password',
          label: 'Password',
          placeholder: 'Enter your password',
          formControlName: 'password'
        },
        
      ]
    }
  ]

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required], //validators.required usernamein girilmesini zorunlu tutar
      password: ['', Validators.required],
      name: [''],
      surname: [''],
      email: ['',Validators.email],
      forgetpassword: []
    });
  }

  private isFormEmpty = (): boolean => {
    return this.loginForm.get('username')?.value === '' || this.loginForm.get('password')?.value === '';
  } //form içindeki username ve passwordu alırız ve boş olup olmadığını kontrol ederiz(ek güvenlik). Burdaki ? işareti null değilse anlamında

  onSubmit() : void {
    if (this.isFormEmpty()) {
       this.loginError = 'Username and password are required';
       return;
    }
    console.log("Form submitted");
  }
  onClick() : void {
    //this.loginForm

  }
  
} */