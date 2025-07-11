import { Component, Inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { isPlatformBrowser, CommonModule, ViewportScroller } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';

@Component({
  selector: 'app-header-nologged',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './header-nologged.html',
  styleUrls: ['./header-nologged.css']
})
export class HeaderNologged {
  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private scroller: ViewportScroller
  ) {}

  isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  scrollTo(anchor: string): void {
    if (this.isBrowser()) {
      this.scroller.scrollToAnchor(anchor);
    }
  }
}
