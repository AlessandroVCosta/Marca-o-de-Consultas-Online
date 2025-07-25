import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment';

@Component({
  selector: 'app-appointment-anon',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointment-anon.html',
  styleUrl: './appointment-anon.css'
})
export class AppointmentAnon {
  numeroUtente: string = '';
  nomeCompleto: string = '';
  dataNascimento: string = '';
  genero: string = '';
  fotografiaUrl: string = '';
  telefone: string = '';
  email: string = '';
  morada: string = '';
  feedback: string | null = null;
  feedbackErro: string | null = null;
  showRegister: boolean = false;
  registerPassword: string = '';
  registerConfirmPassword: string = '';
  registerFeedback: string | null = null;
  registerError: string | null = null;

  constructor(private http: HttpClient) {}

  submitRequest() {
    this.feedback = null;
    this.feedbackErro = null;
    this.showRegister = false;
    const dto = {
      numeroUtente: this.numeroUtente,
      nomeCompleto: this.nomeCompleto,
      dataNascimento: this.dataNascimento,
      genero: this.genero,
      fotografiaUrl: this.fotografiaUrl || null,
      telefone: this.telefone,
      email: this.email,
      morada: this.morada || null
    };
    this.http.post(`${environment.apiBaseUrl}/AnonymousRequest`, dto).subscribe({
      next: () => {
        this.feedback = 'Pedido de marcação enviado com sucesso!';
        this.showRegister = true;
      },
      error: () => {
        this.feedbackErro = 'Erro ao enviar pedido de marcação.';
      }
    });
  }

  criarConta() {
    this.registerFeedback = null;
    this.registerError = null;
    if (this.registerPassword !== this.registerConfirmPassword) {
      this.registerError = 'As senhas não coincidem.';
      return;
    }
    const dto = {
      email: this.email,
      password: this.registerPassword,
      nomeCompleto: this.nomeCompleto,
      role: 0 // Paciente
    };
    this.http.post(`${environment.apiBaseUrl}/Users`, dto).subscribe({
      next: () => {
        this.registerFeedback = 'Conta criada com sucesso! Agora você pode acompanhar seus pedidos.';
      },
      error: () => {
        this.registerError = 'Erro ao criar conta. Tente outro email.';
      }
    });
  }
}
