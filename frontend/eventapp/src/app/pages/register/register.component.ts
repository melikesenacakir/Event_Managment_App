import { Component,Input} from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {NavbarComponent } from '../../components/navbar/navbar.component';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatRadioModule,MatGridListModule,NavbarComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup;
  registerError: string = '';
  @Input() register: boolean=true;
  
  constructor(private fb: FormBuilder, private router: Router) {
    this.registerForm = this.fb.group({
      name: ['', Validators.required], 
      surname: ['', Validators.required],
      email: ['', Validators.required], 
      username: ['', Validators.required], //validators.required usernamein girilmesini zorunlu tutar
      password: ['', Validators.required],
    });
  }

  private isFormEmpty = (): boolean => {
    return this.registerForm.get('username')?.value === '' || this.registerForm.get('password')?.value === '';
  } //form içindeki username ve passwordu alırız ve boş olup olmadığını kontrol ederiz(ek güvenlik). Burdaki ? işareti null değilse anlamında

  openNewPasswordPage(){
      this.router.navigateByUrl('/forgetpass');
      console.log(this.register)
  }
  onSubmit() : void {
    if (this.isFormEmpty()) {
       this.registerError = 'Username and password are required';
       return;
    }
    
  }
  onClick() : void {
    //this.registerForm

  }
}
