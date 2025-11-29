import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {NavbarComponent } from '../../components/navbar/navbar.component';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { EMPTY, empty, firstValueFrom } from 'rxjs';
import { PopupComponent } from '../../components/popup/popup.component';
import { MatDialog } from '@angular/material/dialog';

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
  
  constructor(private fb: FormBuilder, private router: Router, private authService: AuthService, public dialogRef: MatDialog) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required], //validators.required usernamein girilmesini zorunlu tutar
      password: ['', Validators.required],
      forgetpassword: [],
    });
  }

  private isFormEmpty = (): boolean => {
    return this.loginForm.get('username')?.value == '' || this.loginForm.get('password')?.value == '';
  } //form içindeki username ve passwordu alırız ve boş olup olmadığını kontrol ederiz(ek güvenlik). Burdaki ? işareti null değilse anlamında

  openNewPasswordPage(){
      this.router.navigateByUrl('/forgetpass');
      console.log(this.login)
  }
 async onSubmit() : Promise<void> {
    if (this.isFormEmpty()) {
      const inp= this.dialogRef.open(PopupComponent, {
        width: '30vw',
        height: '20vh',
      });
      inp.componentInstance.message = 'Username and password are required';
      return;
    }
    var message = await this.authService.login(this.loginForm.value.username, this.loginForm.value.password);
    if (!message.success) {
      const inp = this.dialogRef.open(PopupComponent, {
        width: '30vw',
        height: '20vh',
      });
      inp.componentInstance.message = message.error || 'Login failed';
    }
     
  } 
}