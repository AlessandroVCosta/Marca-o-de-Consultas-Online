import { Component, Inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';



@Component({
  selector: 'app-login',
  standalone: true,
 imports: [CommonModule, RouterLink],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

isBrowser(): boolean {
  return isPlatformBrowser(this.platformId);
}

}
