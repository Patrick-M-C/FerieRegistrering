import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInStatus = false;
  private currentUserRole: 'admin' | 'medarbejder' | null = null;

  login(username: string, password: string): boolean {
    // Simulerer login (hardkodet test-bruger)
    if (username === 'admin' && password === '1234') {
      this.isLoggedInStatus = true;
      this.currentUserRole = 'admin';
      localStorage.setItem('role', 'admin');
      return true;
    } 
    else if (username === 'medarbejder' && password === '1234') {
      this.isLoggedInStatus = true;
      this.currentUserRole = 'medarbejder';
      localStorage.setItem('role', 'medarbejder');
      return true;
    }
    return false;
  }

  logout() {
    this.isLoggedInStatus = false;
    this.currentUserRole = null;
    localStorage.removeItem('role');
  }

  isLoggedIn(): boolean {
  // Tjekker om role er gemt
  return !!localStorage.getItem('role');
}

getRole(): 'admin' | 'medarbejder' | null {
  return localStorage.getItem('role') as 'admin' | 'medarbejder' | null;
}
}
