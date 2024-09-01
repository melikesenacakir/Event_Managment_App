import { Component,Input} from '@angular/core';
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {NavbarComponent } from '../../components/navbar/navbar.component';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { UsersService } from '../../services/users.service';
import { AuthService } from '../../services/auth.service';
import { MatDialogRef, MatDialogModule, MatDialog } from '@angular/material/dialog';
import { PopupComponent } from '../../components/popup/popup.component';

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
  
  constructor(private fb: FormBuilder, private router: Router, private authService: AuthService,public dialogRef: MatDialog) {
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
  async onClick() : Promise<void> {
    if(this.isFormEmpty()){
      console.log('Username and password are required');
    }
    var message=await this.authService.register(this.registerForm.value);
    if (message!=''){
      const inp= this.dialogRef.open(PopupComponent, {
        width: '30vw',
        height: '20vh',
      });
      inp.componentInstance.message = message;
    }
    
  }
}
