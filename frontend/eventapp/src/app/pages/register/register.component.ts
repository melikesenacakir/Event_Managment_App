import { Component,Input} from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {NavbarComponent } from '../../components/navbar/navbar.component';
import { Router} from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MatDialogRef, MatDialogModule, MatDialog } from '@angular/material/dialog';
import { PopupComponent } from '../../components/popup/popup.component';
import { EMPTY } from 'rxjs';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatRadioModule,MatGridListModule,NavbarComponent,MatDialogModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup;
  registerError: string = '';
  @Input() register: boolean=true;
  
  constructor(private fb: FormBuilder, private router: Router, private authService: AuthService, public dialogRef: MatDialog) {
    this.registerForm = this.fb.group({
      name: ['', Validators.required], 
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      username: ['', Validators.required], 
      password: ['', [Validators.required, Validators.minLength(6)]], 
    });
  }
  private isFormEmpty(): boolean {
    return this.registerForm.get('username')?.value == '' || this.registerForm.get('password')?.value == '' ;
  } 

  openNewPasswordPage() {
    this.router.navigateByUrl('/forgetpass');
    console.log(this.register);
  }


  async onClick(): Promise<void> {
    if (this.isFormEmpty()) {
      console.log("error");
      const inp = this.dialogRef.open(PopupComponent, {
        width: '30vw',
        height: '20vh',
      });
      inp.componentInstance.message = 'Username and password are required';
      return;
    }
    var message=await this.authService.register(this.registerForm.value);
    if (message==EMPTY){
      const inp= this.dialogRef.open(PopupComponent, {
        width: '30vw',
        height: '20vh',
      });
      inp.componentInstance.message = message;
    }
    
  }
}
