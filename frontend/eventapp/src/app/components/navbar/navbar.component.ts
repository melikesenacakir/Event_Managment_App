import { Component } from '@angular/core';
import {MatGridListModule} from '@angular/material/grid-list';
import { RouterLink, RouterOutlet, RouterLinkActive,Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatGridListModule,RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
loggedIn: boolean = false;

  constructor(private router: Router) {
   }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    if(token){
      this.loggedIn = true;
    }
  }
   
  onClick(){
    this.router.navigateByUrl('/home');
  }
  onLogout(){
    localStorage.removeItem('token');
    this.loggedIn = false;
    this.router.navigateByUrl('/');
  }
}
