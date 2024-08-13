import { Component, output } from '@angular/core';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule, } from '@angular/forms';
import { Router } from '@angular/router';
import {MatGridListModule} from '@angular/material/grid-list';
import {NavbarComponent } from '../../../components/navbar/navbar.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-forgetpassword',
  standalone: true,
  imports: [MatGridListModule,NavbarComponent,ReactiveFormsModule,CommonModule],
  templateUrl: './forgetpassword.component.html',
  styleUrl: './forgetpassword.component.scss'
})
export class ForgetpasswordComponent {
  forgetForm: FormGroup;
  outpt: string='';
  
  constructor(private fb: FormBuilder, private router: Router) {
    this.forgetForm = this.fb.group({
      email: ['', [Validators.required,Validators.email]],
    });
  }

  openNewPasswordPage(){
      this.router.navigateByUrl('/forgetpass');
  }
  onSubmit() : void{
    if (this.forgetForm.valid && this.forgetForm.get('email')?.value != ''){
       this.outpt="Email sent successfully. Please check your mailbox!";
       return;
    }
   this.outpt="Email not sent";
  }
}

