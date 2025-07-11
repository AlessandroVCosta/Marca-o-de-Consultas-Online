import { Component } from '@angular/core';
import { HeaderNologged } from '../../core/header-nologged/header-nologged';
import { Footer } from '../../core/footer/footer';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HeaderNologged, Footer],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class Register {

}
