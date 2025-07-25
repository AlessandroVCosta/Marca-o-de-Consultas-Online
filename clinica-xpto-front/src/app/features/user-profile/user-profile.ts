import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../shared/services/auth.service';
import { environment } from '../../../environment/environment';


@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-profile.html',
  styleUrls: ['./user-profile.css']
})
export class UserProfile  implements OnInit {
  user = {
    id: '',
    fullName: '',
    dataNascimento: '',
    genero: '',
    fotografiaUrl: '',
    telefone: '',
    morada: '',
    numeroUtenteSaude: '',
    password: '',
    email: '' // apenas para exibição
  };
  pedidos: any[] = [];
  loadingPedidos = false;
  errorPedidos: string | null = null;
  feedback: string | null = null;
  feedbackErro: string | null = null;

  constructor(private http: HttpClient, private auth: AuthService) {}

  ngOnInit() {
    // Buscar dados do usuário logado
    this.user = {
      id: this.auth.getUserId() || '',
      fullName: this.auth.getUserName() || '',
      dataNascimento: '',
      genero: '',
      fotografiaUrl: '',
      telefone: '',
      morada: '',
      numeroUtenteSaude: '',
      password: '',
      email: this.auth.getUserEmail() || ''
    };
    this.buscarPedidos();
  }

  buscarPedidos() {
    this.loadingPedidos = true;
    this.errorPedidos = null;
    const userId = this.auth.getUserId();
    if (!userId) {
      this.pedidos = [];
      this.loadingPedidos = false;
      return;
    }
    this.http.get<any[]>(`${environment.apiBaseUrl}/AppointmentRequest/user/${userId}`).subscribe({
      next: (data) => {
        this.pedidos = data;
        this.loadingPedidos = false;
      },
      error: (err) => {
        this.errorPedidos = 'Erro ao buscar histórico de pedidos.';
        this.loadingPedidos = false;
      }
    });
  }

  saveProfile() {
    this.feedback = null;
    this.feedbackErro = null;
    const dto = {
      id: this.user.id,
      nomeCompleto: this.user.fullName,
      dataNascimento: this.user.dataNascimento || null,
      genero: this.user.genero || null,
      fotografiaUrl: this.user.fotografiaUrl || null,
      telefone: this.user.telefone || null,
      morada: this.user.morada || null,
      numeroUtenteSaude: this.user.numeroUtenteSaude || null
    };
    this.http.put(`${environment.apiBaseUrl}/Users/${dto.id}`, dto).subscribe({
      next: () => {
        this.feedback = 'Perfil atualizado com sucesso!';
      },
      error: () => {
        this.feedbackErro = 'Erro ao atualizar perfil.';
      }
    });
  }

  exportarPdf(id: string) {
    this.http.get(`${environment.apiBaseUrl}/AppointmentRequest/${id}/pdf`, { responseType: 'blob' }).subscribe({
      next: (blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = `Pedido_${id}.pdf`;
        a.click();
        window.URL.revokeObjectURL(url);
      },
      error: () => {
        alert('Erro ao exportar PDF.');
      }
    });
  }
}