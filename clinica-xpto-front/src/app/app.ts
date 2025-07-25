import { Component, Inject, effect, signal } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { PLATFORM_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { Header } from './core/header/header';
import { HeaderNologged } from './core/header-nologged/header-nologged';
import { Footer } from './core/footer/footer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, Header, HeaderNologged, Footer, HttpClientModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  hydrated = signal(false);
  private isBrowserPlatform = false;

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {
    this.isBrowserPlatform = isPlatformBrowser(this.platformId);
    if (this.isBrowserPlatform) {
      effect(() => this.hydrated.set(true));
    }
  }

  isLoggedIn(): boolean {
    return this.isBrowserPlatform && !!localStorage.getItem('token');
  }
}
