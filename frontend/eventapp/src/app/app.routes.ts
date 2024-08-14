import { Routes } from '@angular/router';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ForgetpasswordComponent } from './pages/login/forgetpassword/forgetpassword.component';
import { RegisterComponent } from './pages/register/register.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { EventComponent } from './pages/event/event.component';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: ProfileComponent},
    {path: 'forgetpass', component: ForgetpasswordComponent},
    {path: 'profile',component: ProfileComponent},
    {path: 'events',component: EventComponent},
    {path: '**', component: NotFoundComponent } //iki yıldız içerisindeki hiçbir pathle eşleşmiyorsa demektir.
];
