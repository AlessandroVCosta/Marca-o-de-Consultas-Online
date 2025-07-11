import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-admin-panel',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './admin-panel.html',
  styleUrl: './admin-panel.css'
})
export class AdminPanel {

constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

isBrowser(): boolean {
  return isPlatformBrowser(this.platformId);
}

 cards = [
    { title: 'Utilizadores', icon: '👥', route: '/users' },
    { title: 'Serviços', icon: '🩺', route: '/services' },
    { title: 'Relatórios', icon: '📊', route: '/reports' },
    { title: 'Configurações', icon: '⚙️', route: '/settings' }
  ];
}
