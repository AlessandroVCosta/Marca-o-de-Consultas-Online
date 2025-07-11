import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dashboard-admin.html',
  styleUrl: './dashboard-admin.css'
})
export class DashboardAdmin {
  searchTerm = '';

  appointments = [
    { user: 'Sophia Clark', service: 'Checkup', date: '2024-07-20', status: 'Pending' },
    { user: 'Ethan Carter', service: 'Dental', date: '2024-07-21', status: 'Confirmed' },
    { user: 'Olivia Bennett', service: 'Fisioterapia', date: '2024-07-22', status: 'Rescheduled' },
    { user: 'Liam Foster', service: 'Dermatologia', date: '2024-07-23', status: 'Cancelled' },
    { user: 'Ava Harper', service: 'Nutrição', date: '2024-07-24', status: 'Pending' }
  ];

  get filteredAppointments() {
    const term = this.searchTerm.toLowerCase();
    return this.appointments.filter(a =>
      a.user.toLowerCase().includes(term) ||
      a.service.toLowerCase().includes(term) ||
      a.date.includes(term)
    );
  }
}