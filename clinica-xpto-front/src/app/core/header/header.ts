import { Component, Inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { isPlatformBrowser, CommonModule, ViewportScroller } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './header.html',
  styleUrls: ['./header.css']
})
export class Header {
  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private scroller: ViewportScroller,
    public auth: AuthService
  ) {}

  isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  scrollTo(anchor: string) {
    if (this.isBrowser()) {
      this.scroller.scrollToAnchor(anchor);
    }
  }
 
  logout() {
    if (this.isBrowser()) {
      this.auth.logout();
      window.location.href = '/';
    }
  }
}
