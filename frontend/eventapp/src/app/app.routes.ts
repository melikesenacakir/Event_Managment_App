import { Routes } from '@angular/router';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { ForgetpasswordComponent } from './pages/login/forgetpassword/forgetpassword.component';
import { RegisterComponent } from './pages/register/register.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { EventComponent } from './pages/event/event.component';
import { EventCardComponent } from './components/event-card/event-card.component';
import { JoinComponent } from './components/event-card/join/join.component';
import { EventJoinCardComponent } from './components/event-join-card/event-join-card.component';
import { UserEventsComponent } from './pages/event/user-events/user-events.component';
import { SendMessageComponent } from './components/send-message/send-message.component';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: HomeComponent},
    {path: 'forgetpass', component: ForgetpasswordComponent},
    {path: 'profile',component: ProfileComponent},
    {path: 'events',component: EventComponent},
    {path: 'events/:id',component: EventCardComponent},
    {path: 'join',component: JoinComponent},
    {path: 'myevents',component: UserEventsComponent},
    {path: 'myevents/:id',component: EventCardComponent},
    {path: 'myevents/:id/join',component: EventJoinCardComponent},
    {path: 'myevents/:id/send',component: SendMessageComponent},
    {path: '**', component: NotFoundComponent } //iki yıldız içerisindeki hiçbir pathle eşleşmiyorsa demektir.
];
