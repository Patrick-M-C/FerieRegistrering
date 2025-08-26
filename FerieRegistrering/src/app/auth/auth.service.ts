import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;
  currentUser: any = null;
  users: any;

  constructor(private router: Router) {}

  login(username: string, password: string): boolean {
    if (username === 'Admin' && password === 'Admin') {
      this.isLoggedIn = true;
      this.currentUser = { username, role: 'admin' };
      this.router.navigate(['/admin']);
      return true;
    }
    return false;
  }

  logout(): void {
  this.isLoggedIn = false;
  this.currentUser = null;
  this.router.navigate(['/login']);
}


  getUsers() {
    return this.users;
  }

  addUser(username: string, password: string, role: string) {
    this.users.push({ username, password, role });
  }
}