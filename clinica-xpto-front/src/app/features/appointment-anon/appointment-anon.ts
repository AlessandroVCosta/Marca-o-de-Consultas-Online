import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-appointment-anon',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointment-anon.html',
  styleUrl: './appointment-anon.css'
})
export class AppointmentAnon {
 fullName: string = '';
  email: string = '';
  service: string = '';
  date: string = '';
  message: string = '';

  submitRequest() {
    console.log('Marcação enviada:', {
      fullName: this.fullName,
      email: this.email,
      service: this.service,
      date: this.date,
      message: this.message,
    });

    // Depois conectaremos com a API real
    alert('Pedido de marcação enviado com sucesso!');
  }
}
