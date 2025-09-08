import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user: { isLoggedIn: boolean; isAdmin: boolean } | null = null;

  // Simuleret login-status (i praksis vil dette tjekke mod en token eller API)
  isLoggedIn(): boolean {
    return !!this.user?.isLoggedIn;
  }

  isAdmin(): boolean {
    return this.isLoggedIn() && this.user?.isAdmin === true;
  }

  // Eksempel på login-metode
  login(username: string, password: string): Observable<boolean> {
    // Simuleret login-logik
    this.user = { isLoggedIn: true, isAdmin: username === 'admin' };
    return of(true);
  }

  logout(): void {
    this.user = null;
  }
}

