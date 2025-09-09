import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user: { isLoggedIn: boolean; isAdmin: boolean; username: string; password: string } | null = null;

  isLoggedIn(): boolean {
    return !!this.user?.isLoggedIn;
  }

  isAdmin(): boolean {
    return this.isLoggedIn() && this.user?.isAdmin === true;
  }

  login(username: string, password: string): Observable<boolean> {
    const validUsers = {
      admin: { password: 'admin123', isAdmin: true },
      user1: { password: 'user123', isAdmin: false },
      user2: { password: 'pass456', isAdmin: false }
    };

    const userCredentials = validUsers[username as keyof typeof validUsers];

    if (userCredentials && userCredentials.password === password) {
      this.user = {
        isLoggedIn: true,
        isAdmin: userCredentials.isAdmin,
        username,
        password
      };
      return of(true);
    }
    return of(false);
  }

  logout(): void {
    this.user = null;
  }

  getUser() {
    return this.user;
  }

  updateUser(updatedUser: any) {
    if (this.user) {
      this.user = { ...this.user, ...updatedUser };
    }
  }
}
