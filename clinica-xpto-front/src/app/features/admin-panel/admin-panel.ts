import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-admin-panel',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './admin-panel.html',
  styleUrl: './admin-panel.css'
})
export class AdminPanel {

 cards = [
    { title: 'Utilizadores', icon: '👥', route: '/users' },
    { title: 'Serviços', icon: '🩺', route: '/services' },
    { title: 'Relatórios', icon: '📊', route: '/reports' },
    { title: 'Configurações', icon: '⚙️', route: '/settings' }
  ];
}
