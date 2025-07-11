import { Component, Inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class Register {

constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

isBrowser(): boolean {
  return isPlatformBrowser(this.platformId);
}
}
