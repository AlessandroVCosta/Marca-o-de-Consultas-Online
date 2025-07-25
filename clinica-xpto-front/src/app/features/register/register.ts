import { Component, Inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class Register {
  form = {
    nomeCompleto: '',
    email: '',
    password: '',
    confirmarSenha: '',
    dataNascimento: '',
    genero: '',
    telefone: '',
    morada: '',
    fotografiaUrl: '',
    numeroUtenteSaude: ''
  };
  loading = false;
  error: string | null = null;
  success: boolean = false;

  constructor(@Inject(PLATFORM_ID) private platformId: Object, private auth: AuthService) {}

  isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  onSubmit() {
    this.error = null;
    this.success = false;
    if (this.form.password !== this.form.confirmarSenha) {
      this.error = 'As senhas não coincidem';
      return;
    }
    this.loading = true;
    const dto = {
      nomeCompleto: this.form.nomeCompleto,
      email: this.form.email,
      password: this.form.password,
      role: 0, // Paciente
      dataNascimento: this.form.dataNascimento || null,
      genero: this.form.genero || null,
      telefone: this.form.telefone || null,
      morada: this.form.morada || null,
      fotografiaUrl: this.form.fotografiaUrl || null,
      numeroUtenteSaude: this.form.numeroUtenteSaude || null
    };
    this.auth.register(dto).subscribe({
      next: () => {
        this.success = true;
        this.loading = false;
      },
      error: (err) => {
        this.error = err?.error?.message || 'Erro ao registrar';
        this.loading = false;
      }
    });
  }
}
