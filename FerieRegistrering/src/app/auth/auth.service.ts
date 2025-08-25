import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUser: { username: string, role: string } | null = null;

  constructor(private router: Router) {}

  login(username: string, password: string): boolean {
    // Dummy login (kan udskiftes med API senere)
    if (username === 'admin' && password === 'admin123') {
      this.currentUser = { username, role: 'admin' };
      this.router.navigate(['/admin']);
      return true;
    } else if (username === 'user' && password === 'user123') {
      this.currentUser = { username, role: 'user' };
      this.router.navigate(['/ferie']);
      return true;
    }
    return false;
  }

  logout() {
    this.currentUser = null;
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return this.currentUser !== null;
  }

  getRole(): string | null {
    return this.currentUser ? this.currentUser.role : null;
  }
}
