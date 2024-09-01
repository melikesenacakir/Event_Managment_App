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
     if (this.isFormEmpty()) {
       this.loginError = 'Username and password are required';
       return;
    }
    
}
  
}