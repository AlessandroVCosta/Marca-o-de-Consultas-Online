import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-appointment-user',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointment-user.html',
  styleUrl: './appointment-user.css'
})
export class AppointmentUser implements OnInit {
  fullName: string = '';
  email: string = '';
  service: string = '';
  date: string = '';
  message: string = '';

  ngOnInit() {
    // Simulação: nome e email já vêm do "usuário logado"
    this.fullName = 'Maria Fernandes';
    this.email = 'maria@email.com';
  }

  submitRequest() {
    console.log('Pedido de marcação do usuário logado:', {
      fullName: this.fullName,
      email: this.email,
      service: this.service,
      date: this.date,
      message: this.message,
    });

    alert('Pedido de marcação enviado com sucesso!');
  }
}