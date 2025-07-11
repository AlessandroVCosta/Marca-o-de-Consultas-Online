import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { HeaderNologged } from '../../core/header-nologged/header-nologged';
import { Footer } from '../../core/footer/footer';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HeaderNologged, Footer, RouterLink],
  templateUrl: './home.html',
  styleUrls: ['./home.css']
})
export class Home {}
