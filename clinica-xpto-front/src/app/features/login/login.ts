import { Component } from '@angular/core';
import { HeaderNologged } from '../../core/header-nologged/header-nologged';
import { Footer } from '../../core/footer/footer';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HeaderNologged, Footer],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class Login {

}
