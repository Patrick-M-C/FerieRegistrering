import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user: { isLoggedIn: boolean; isAdmin: boolean } | null = null;

  isLoggedIn(): boolean {
    return !!this.user?.isLoggedIn;
  }

  isAdmin(): boolean {
    return this.isLoggedIn() && this.user?.isAdmin === true;
  }

  login(username: string, password: string): Observable<boolean> {
    this.user = { isLoggedIn: true, isAdmin: username === 'admin' };
    return of(true);
  }

  logout(): void {
    this.user = null;
  }
}

