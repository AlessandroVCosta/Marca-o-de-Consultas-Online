import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment';
import { AuthService } from '../../shared/services/auth.service';

interface ActoClinico {
  actTypeId: string;
  subsystem: number;
  professionalId?: string;
  dataInicioSolicitado: string;
  dataFimSolicitado: string;
  horaSolicitada?: string;
  observacoes?: string;
}

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
  userId: string = '';
  actos: ActoClinico[] = [];
  actTypes: any[] = [];
  professionals: any[] = [];
  healthSubsystems = [
    { value: 0, label: 'SNS' },
    { value: 1, label: 'Medis' },
    { value: 2, label: 'ADM' },
    { value: 3, label: 'Multicare' },
    { value: 4, label: 'AdvanceCare' },
    { value: 5, label: 'Allianz' },
    { value: 6, label: 'Unilife' },
    { value: 7, label: 'ADSE' },
    { value: 8, label: 'Particular' },
    { value: 9, label: 'Outros' }
  ];
  loading = false;
  success = false;
  error: string | null = null;

  constructor(private http: HttpClient, private auth: AuthService) {}

  ngOnInit() {
    // Simulação: nome e email já vêm do "usuário logado"
    this.fullName = 'Maria Fernandes';
    this.email = 'maria@email.com';
    this.userId = '';
    this.actos = [this.novoActo()];
    this.fetchActTypes();
    this.fetchProfessionals();
  }

  novoActo(): ActoClinico {
    return {
      actTypeId: '',
      subsystem: 0,
      professionalId: '',
      dataInicioSolicitado: '',
      dataFimSolicitado: '',
      horaSolicitada: '',
      observacoes: ''
    };
  }

  addActo() {
    this.actos.push(this.novoActo());
  }

  removeActo(idx: number) {
    this.actos.splice(idx, 1);
  }

  fetchActTypes() {
    this.http.get<any[]>(`${environment.apiBaseUrl}/ActType`).subscribe(data => {
      this.actTypes = data;
    });
  }

  fetchProfessionals() {
    this.http.get<any[]>(`${environment.apiBaseUrl}/Professional`).subscribe(data => {
      this.professionals = data;
    });
  }

  submitRequest() {
    this.error = null;
    this.success = false;
    this.loading = true;
    if (this.actos.some(a => !a.actTypeId)) {
      this.error = 'Todos os actos clínicos devem ter um tipo selecionado.';
      this.loading = false;
      return;
    }
    const userId = this.auth.getUserId();
    const dto = {
      userId: userId && userId !== '' ? userId : null,
      items: this.actos.map(a => ({
        actTypeId: a.actTypeId,
        subsystem: a.subsystem,
        professionalId: a.professionalId && a.professionalId !== '' ? a.professionalId : null,
        dataInicioSolicitado: a.dataInicioSolicitado ? a.dataInicioSolicitado : null,
        dataFimSolicitado: a.dataFimSolicitado ? a.dataFimSolicitado : null,
        horaSolicitada: a.horaSolicitada ? (a.horaSolicitada.length === 5 ? a.horaSolicitada + ':00' : a.horaSolicitada) : null,
        observacoes: a.observacoes && a.observacoes.trim() !== '' ? a.observacoes : null
      }))
    };
    // Validação extra: datas obrigatórias
    if (dto.items.some(item => !item.dataInicioSolicitado || !item.dataFimSolicitado)) {
      this.error = 'Todos os actos clínicos devem ter data de início e fim.';
      this.loading = false;
      return;
    }
    this.http.post(`${environment.apiBaseUrl}/AppointmentRequest`, dto).subscribe({
      next: () => {
        this.success = true;
        this.loading = false;
        this.actos = [this.novoActo()];
      },
      error: (err) => {
        this.error = err?.error?.message || 'Erro ao enviar pedido';
        this.loading = false;
      }
    });
  }
}