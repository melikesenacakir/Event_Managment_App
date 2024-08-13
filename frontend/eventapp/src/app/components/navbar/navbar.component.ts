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

  constructor(private router: Router) { }
   
  onClick(){
    this.router.navigateByUrl('/home');
  }
}
