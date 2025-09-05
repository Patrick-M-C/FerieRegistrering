import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  getUser(): any {
      throw new Error('Method not implemented.');
  }
  isLoggedIn = false;
  currentUser: any = null;
  users: any[] = [];

  constructor(private router: Router) {}

  login(username: string, password: string): boolean {
    if (username === 'Admin' && password === 'Admin') {
      this.isLoggedIn = true;
      this.currentUser = { username: 'admin', email: 'admin@example.com', role: 'admin' };
      this.router.navigate(['/admin']);
      return true;
    } else if (username === 'User' && password === 'User') {
      this.isLoggedIn = true;
      this.currentUser = { username: 'user', email: 'user@example.com', role: 'user' };
      this.router.navigate(['/home']);
      return true;
    }
    return false;
  }

  logout(): void {
    this.isLoggedIn = false;
    this.currentUser = null;
    this.router.navigate(['/login']);
  }

  getRole(): string | null {
    return this.currentUser ? this.currentUser.role : null;
  }

  updateUser(updateUser: any) {
    this.currentUser = { ...this.currentUser, ...updateUser };
  }
}
