import { Component } from '@angular/core';
import { RouterLink, RouterLinkWithHref } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.css'],
  imports: [CommonModule, RouterLink, RouterLinkWithHref]
})
export class Sidebar {
  // No futuro: pode vir a usar role para mostrar menus diferentes
}
