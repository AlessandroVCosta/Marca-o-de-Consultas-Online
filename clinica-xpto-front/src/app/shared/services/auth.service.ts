import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequestDto } from '../models/login-request.dto';
import { LoginResponseDto } from '../models/login-response.dto';
import { environment } from '../../../environment/environment';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiBaseUrl}/Users`; // Ajuste se o endpoint for diferente

  private http = inject(HttpClient);

  login(data: LoginRequestDto): Observable<LoginResponseDto> {
    return this.http.post<LoginResponseDto>(`${this.apiUrl}/login`, data).pipe(
      tap((res: LoginResponseDto) => {
        localStorage.setItem('authToken', res.token);
        localStorage.setItem('userId', res.userId);
        localStorage.setItem('userName', res.nome);
        localStorage.setItem('userEmail', res.email);
        localStorage.setItem('userRole', res.role);
      })
    );
  }

  register(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, data);
  }

 
  logout() {
    localStorage.clear(); // ou remova individualmente
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('authToken');
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  getUserId(): string | null {
    return localStorage.getItem('userId');
  }

  getUserName(): string | null {
    return localStorage.getItem('userName');
  }

  getUserEmail(): string | null {
    return localStorage.getItem('userEmail');
  }

  getUserRole(): string | null {
    return localStorage.getItem('userRole');
  }
}
