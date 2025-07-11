import { Component } from '@angular/core';
import { RouterLink, RouterLinkWithHref } from '@angular/router';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-header-nologged',
  standalone: true,
  templateUrl: './header-nologged.html',
  styleUrls: ['./header-nologged.css'],
  imports: [CommonModule, RouterLink, RouterLinkWithHref]
})
export class HeaderNologged {

}
