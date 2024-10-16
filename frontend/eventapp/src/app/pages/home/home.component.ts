import { Component } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { EventCardComponent } from '../../components/event-card/event-card.component';
import { firstValueFrom } from 'rxjs';
import { HomepageService } from '../../services/homepage.service';
import { CommonModule } from '@angular/common';
import { Events } from '../../datasources/event.datasource';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent,EventCardComponent,CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
events = [];

constructor(private homepageService: HomepageService) {}

ngOnInit(): void {
  this.getHomepage();
}


async getHomepage(): Promise<void> {
  try {
    const evnt = await firstValueFrom(this.homepageService.getHomepage());
    if (evnt) {
      this.events = evnt as Event[];
      console.log("Events:", this.events);
    }
  } catch (error) {
    console.error("Error fetching event:", error);
  }
}
}