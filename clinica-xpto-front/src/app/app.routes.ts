import { Routes } from '@angular/router';
import { Login } from './features/login/login';
import { Register } from './features/register/register';
import { Home } from './features/home/home';
import { AppointmentAnon } from './features/appointment-anon/appointment-anon';
import { AppointmentUser } from './features/appointment-user/appointment-user';
import { DashboardAdmin } from './features/dashboard-admin/dashboard-admin';
import { AdminPanel } from './features/admin-panel/admin-panel';
import { UserProfile } from './features/user-profile/user-profile';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'home', component: Home },
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'appointment-anon', component: AppointmentAnon },
  { path: 'appointment-user', component: AppointmentUser },
  { path: 'dashboard-admin', component: DashboardAdmin },
  { path: 'admin-panel', component: AdminPanel },
  { path: 'user-profile', component: UserProfile }
];
