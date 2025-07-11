import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-profile.html',
  styleUrls: ['./user-profile.css']
})
export class UserProfile  implements OnInit {
  user = {
    fullName: '',
    email: '',
    phone: '',
    password: '',
  };

  ngOnInit() {
    // Simular dados do usuário autenticado
    this.user = {
      fullName: 'Maria Fernandes',
      email: 'maria@email.com',
      phone: '+244 923 456 789',
      password: '',
    };
  }

  saveProfile() {
    console.log('Dados atualizados:', this.user);
    alert('Perfil atualizado com sucesso!');
  }
}