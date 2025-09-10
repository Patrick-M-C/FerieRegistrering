import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { environment } from '../Environments/environments';
import { auth } from '../models/auth';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly AuthApiUrl = environment.apiUrl + '/Auth';
  private tokenKey = 'auth_token';
  private roleKey = 'auth_role';

  constructor(private http: HttpClient) {}

  login(request: any): Observable<auth> {
    return this.http.post<auth>(`${this.AuthApiUrl}/login`, request).pipe(
      tap((response) => {
        if (response?.token) {
          localStorage.setItem(this.tokenKey, response.token);
          localStorage.setItem(this.roleKey, this.normalizeRole(response.role));
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.roleKey);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  getRole(): 'Employee' | 'Leader' | null {
    const stored = localStorage.getItem(this.roleKey);
    return stored === 'Leader' ? 'Leader'
         : stored === 'Employee' ? 'Employee'
         : null;
  }

  isLeader(): boolean {
    return this.getRole() === 'Leader';
  }

  isEmployee(): boolean {
    return this.getRole() === 'Employee';
  }

  private normalizeRole(role: any): 'Employee' | 'Leader' {
    if (role === 1 || role === 'Leader') return 'Leader';
    return 'Employee';
  }
  
  getUserId(): number | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return +payload.sub || null;
    } catch {
      return null;
    }
  }
}
