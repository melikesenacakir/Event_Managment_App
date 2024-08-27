import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-main-event',
  standalone: true,
  imports: [RouterOutlet],
  template: `<router-outlet></router-outlet>`,
})
export class MainEventComponent {
//eğer child route tanımlanacaksa ayrı bir main component açılır ve içine router outlet tanımlanır. Sonra da routerda ana componenet default belirlenir ve childlar ona bağlanır
}
