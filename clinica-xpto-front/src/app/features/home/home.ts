import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './home.html',
  styleUrls: ['./home.css']
})
export class Home {

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

isBrowser(): boolean {
  return isPlatformBrowser(this.platformId);
}

}
