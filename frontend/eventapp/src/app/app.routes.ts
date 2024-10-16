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
import { OrganizationComponent } from './pages/event/organization/organization.component';
import { AppComponent } from './app.component';
import { MainEventComponent } from './pages/event/main-event/main-event.component';
import { authGuard } from './auth.guard';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: HomeComponent,canActivate: [authGuard]},
    {path: 'forgetpass', component: ForgetpasswordComponent},
    {path: 'profile',component: ProfileComponent,canActivate: [authGuard]},
    {path: 'events',component: MainEventComponent, children: [{path: 'join', component: JoinComponent},{path: '',component:EventComponent},{path: '',pathMatch: 'full',redirectTo: 'events'}],canActivate: [authGuard]},
    {path: 'feedback',component: FeedbacksComponent,canActivate: [authGuard]},
    {path: 'myevents',component: UserEventsComponent,canActivate: [authGuard]},
    {path: 'filter',component: EventFilterComponent,canActivate: [authGuard]},
    {path: 'organization', component: OrganizationComponent,canActivate: [authGuard]},
    {path: '**', component: NotFoundComponent } //iki yıldız içerisindeki hiçbir pathle eşleşmiyorsa demektir.
];
