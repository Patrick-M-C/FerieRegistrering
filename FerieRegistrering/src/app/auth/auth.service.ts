import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { LoginRequest } from '../models/login';
import { HttpClient } from '@angular/common/http';
import { auth } from '../models/auth';
import { environment } from '../Environments/environments';
import { isPlatformBrowser } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly AuthApiUrl = environment.apiUrl + '/Auth';
  private tokenKey = 'auth_token';

  constructor(
    private http: HttpClient,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  private get canUseStorage(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  login(request: LoginRequest): Observable<auth> {
    return this.http.post<auth>(`${this.AuthApiUrl}/login`, request).pipe(
      tap(response => {
        if (response?.token && this.canUseStorage) {
          localStorage.setItem(this.tokenKey, response.token);
        }
      })
    );
  }

  logout(): void {
    if (this.canUseStorage) {
      localStorage.removeItem(this.tokenKey);
    }
  }

  getToken(): string | null {
    return this.canUseStorage ? localStorage.getItem(this.tokenKey) : null;
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
