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
import { UserEventsComponent } from './pages/event/user-events/user-events.component';
import { FeedbacksComponent } from './pages/event/feedbacks/feedbacks.component';
import { EventFilterComponent } from './components/event-filter/event-filter.component';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: HomeComponent},
    {path: 'forgetpass', component: ForgetpasswordComponent},
    {path: 'profile',component: ProfileComponent},
    {path: 'events',component: EventComponent},
    {path: 'events/:id',component: EventCardComponent},
    {path: 'join',component: JoinComponent}, //id ekle
    {path: 'feedback',component: FeedbacksComponent},
    {path: 'myevents',component: UserEventsComponent},
    {path: 'filter',component: EventFilterComponent},
    {path: '**', component: NotFoundComponent } //iki yıldız içerisindeki hiçbir pathle eşleşmiyorsa demektir.
];
