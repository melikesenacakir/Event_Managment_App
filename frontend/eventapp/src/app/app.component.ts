import { Component } from '@angular/core';
import { RouterLink, RouterOutlet, RouterLinkActive } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { MatDialog, MatDialogModule,MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginComponent,NavbarComponent,RouterOutlet, RouterLink, RouterLinkActive, ProfileComponent, MatDialogModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'eventapp';
}
